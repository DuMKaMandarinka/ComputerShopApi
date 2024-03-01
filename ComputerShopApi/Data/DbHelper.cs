using ComputerShopApi.DTO;
using ComputerShopApi.Models;
using System.Net;
using System.IO;
using ComputerShopApi.Response;
using ComputerShopApi.WorkLogics;
using Microsoft.VisualBasic;
using System.Xml.Linq;

namespace ComputerShopApi.Data
{
    public class DbHelper
    {
        private ApiDbContext _context;
        public DbHelper(ApiDbContext context)
        {
            _context = context;
        }

        public void CreateCompany(CompanyDTO companyDTO)
        {
            Company NewCompany = new Company();
            NewCompany.Name = companyDTO.Name;
            _context.Companys.Add(NewCompany);
            _context.SaveChanges();
        }

        public void CreateSales(SalesDto saleDTO)
        {
            AmountSales NewSales = new AmountSales();
            NewSales.Amount = saleDTO.Amount;
            NewSales.Product_Id = saleDTO.Product_Id;
            NewSales.Product = _context.Products.Where(x => x.Id == saleDTO.Product_Id).FirstOrDefault();
            _context.AmountSales.Add(NewSales);
            _context.SaveChanges();
        }

        public void UpdateSales(int id,int Amount)
        {
            AmountSales amountSales = _context.AmountSales.Where(x => x.Id == id).FirstOrDefault();
            if (amountSales != null)
            {
                amountSales.Amount = Amount;
                _context.AmountSales.Update(amountSales);
            }
            _context.SaveChanges();
        }

        public void MakeSales(MakeSalesDTO salesDTO)
        {
            BranchProductModel branchProductModel = _context.BranchProducts.Where(x=>x.BranchId==salesDTO.Branch_Id&&x.ProductId==salesDTO.Product_Id).FirstOrDefault();
            if (branchProductModel!=null)
            {
                if (branchProductModel.Amount > 0)
                {
                    Sales sales = new Sales();
                    sales.UserId = salesDTO.User_Id;
                    sales.ProductId = salesDTO.Product_Id;
                    sales.Product = _context.Products.Where(x => x.Id == salesDTO.Product_Id).FirstOrDefault();
                    sales.BranchId = salesDTO.Branch_Id;
                    sales.DateTime = DateTime.Now;
                    AmountSales amountSales = _context.AmountSales.Where(x=>x.Product_Id==salesDTO.Product_Id).FirstOrDefault();
                    if(amountSales!=null)
                    {
                        amountSales.Amount = amountSales.Amount + 1;
                        _context.AmountSales.Update(amountSales);
                    }
                    BranchProductModel branchProduct = _context.BranchProducts.Where(x=>x.BranchId == salesDTO.Branch_Id&&x.ProductId==salesDTO.Product_Id).FirstOrDefault();
                    if (branchProduct != null)
                    {
                       branchProduct.Amount = branchProduct.Amount-1;
                        _context.BranchProducts.Update(branchProduct);
                    }
                    _context.Sales.Add(sales);
                    _context.SaveChanges();
                }
            }
        }

        public List<PopularProduct> GetMostPopularProducts()
        {
            List<PopularProduct> response = new List<PopularProduct>();

            var data = _context.Products.Join(_context.AmountSales,
                p => p.Id,
                a => a.Product_Id,
                (p, a) => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Id = a.Id,
                    Amount = a.Amount
                }
                ).ToList();

            data = data.OrderByDescending(c => c.Amount).Take(3).ToList();

            data.ForEach(row => response.Add(new PopularProduct()
            {
                Id = row.Id,
                Name = row.Name,
                Price = row.Price,
                Amount = row.Amount
            }));

            return response;
          
        }

        public List<SalesResponse> GetInformation(int id)
        {
            List<SalesResponse> salesResponses = new List<SalesResponse>();
            var sales = _context.Sales.Where(x => x.ProductId == id).ToList();
            foreach(var s in sales)
            {
                SalesResponse saleResponse = new SalesResponse();
                saleResponse.UserId = s.UserId;
                saleResponse.BranchId = s.BranchId;
                saleResponse.ProductId = s.ProductId;
                saleResponse.DateTime = s.DateTime;
                salesResponses.Add(saleResponse);
            }
            return salesResponses;
        }

        public void CreateBranch(BranchDTO BranchDTO)
        {
            Branch NewBranch = new Branch();
            NewBranch.CompanyId = BranchDTO.Company_Id;
            _context.Branches.Add(NewBranch);
            _context.SaveChanges();
        }

        public void DistributionProduct(DistributionDTO DistributionDTO)
        {
            BranchProductModel branchProductModel = new BranchProductModel();
            branchProductModel.ProductId = DistributionDTO.ProductId;
            Product product = _context.Products.FirstOrDefault(x => x.Id == DistributionDTO.ProductId);
            branchProductModel.Product = product;
            Branch branch = _context.Branches.FirstOrDefault(x => x.Id == DistributionDTO.BranchId);
            branchProductModel.Branch = branch;
            branchProductModel.BranchId = DistributionDTO.BranchId;
            branchProductModel.Amount = DistributionDTO.CountProduct;
            _context.BranchProducts.Add(branchProductModel);
            _context.SaveChanges();
        }

        public List<BranchProductModel> GetBranchProducts(int id)
        {
            var dataList = _context.BranchProducts.Where(x => x.Id == id);
            return dataList.ToList();
        }

        public List<Product> GetBranchs()
        {
            List<Product> response = new List<Product>();
            var dataList = _context.Products.ToList();
            dataList.ForEach(row => response.Add(new Product()
            {
                Id = row.Id,
                Name = row.Name
            }));
            return response;

        }

        public async Task CreateProduct(ProductDTO productDto)
        {
            Product NewProduct = new Product();
            NewProduct.Name = productDto.Name;
            NewProduct.Price = productDto.Price;

            //работа с файлами
            //FileInfo fileInfo = new FileInfo(productDto.FormFile.FileName);


            //if (fileInfo.Extension == ".png" || fileInfo.Extension == ".jpg" || fileInfo.Extension == ".jpeg")
            //{
            //    string path = Path.Combine(Directory.GetCurrentDirectory(), "Files", Path.GetRandomFileName());

            //    using (Stream stream = new FileStream(path, FileMode.Create))
            //    {
            //        productDto.FormFile.CopyTo(stream);
            //    }
            //    NewProduct.FilePath = path;
            //}
            //else
            //{
            //    throw new Exception();
            //}

            //работа с файлами//


            

            if(productDto.DevicesId is List<int>)
            {
                SetProduct NewSetProduct = new SetProduct();
                NewSetProduct.ProductId = NewProduct.Id;
                NewProduct.Type = "SetProduct";     
                NewSetProduct.Devices = new List<Device>();
                foreach (var deviceId in productDto.DevicesId)
                {
                    var device = _context.Devices
                    .Where(b => b.Id == deviceId)
                    .FirstOrDefault();
                    if(device != null)
                    {
                        NewSetProduct.Devices.Add(device);
                    }
                    
                }
                NewProduct.SetProduct = NewSetProduct;
                _context.Products.Add(NewProduct);
                _context.SetProducts.Add(NewSetProduct);
                await _context.SaveChangesAsync();
            }
            else if(/*productDto.BrandId !=null &&*/ productDto.TypeId != null)
            {
                Device NewDevice = new Device();
                NewDevice.ProductId = NewProduct.Id;
                //NewDevice.BrandId = (int)productDto.BrandId;
                NewDevice.TypeId = (int)productDto.TypeId;
                NewProduct.Type = "Device";
                NewProduct.Device = NewDevice;
                _context.Products.Add(NewProduct);
                _context.Devices.Add(NewDevice);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }


            //SetProduct NewSetProduct = new SetProduct();
            //NewSetProduct.ProductId = productDto.Id;
            //NewProduct.SetProduct = NewSetProduct;
            //_context.Products.Add(NewProduct);
            //_context.SetProducts.Add(NewSetProduct);
            //await _context.SaveChangesAsync();
        }

        public void DeleteProduct(int id)
        {
            Product Product = _context.Products.Where(x => x.Id == id).FirstOrDefault();
            Device device = _context.Devices.Where(device => device.ProductId == id).FirstOrDefault();
            if (Product != null && device!=null)
            {
                _context.Products.Remove(Product);
                _context.Devices.Remove(device);
            }
            _context.SaveChanges();
        }

        //public void CreateBrand(BrandTypeDTO brandDTO)
        //{
        //    Brand NewBrand = new Brand();
        //    NewBrand.Name = brandDTO.Name;
        //    _context.Brands.Add(NewBrand);
        //    _context.SaveChanges();
        //}


        public List<DeviceResponse> GetDevices()
        {
            List<DeviceResponse> response = new List<DeviceResponse>();
            var dataList = _context.Products.Where(x=> x.Type=="Device").ToList();
            dataList.ForEach(row => response.Add(new DeviceResponse()
            {
                Name = row.Name,
                Price = row.Price
            }));
            return response;
        }

        public List<SetProductResponse> GetSetProduct()
        {
            List<SetProductResponse> response = new List<SetProductResponse>();

            var data = _context.Products.Join(_context.SetProducts,
                p => p.Id,
                st => st.ProductId,
                (p, st) => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Id = st.Id,
                    Compoud = st.Devices
                }).ToList() ;

            foreach(var a in data)
            {
                if (a.Name != "string")
                {
                    SetProductResponse setProductResponse = new SetProductResponse();
                    setProductResponse.Name = a.Name;
                    setProductResponse.Price = a.Price;
                    setProductResponse.Id = a.Id;
                    setProductResponse.Сompound =a.Compoud;
                    response.Add(setProductResponse);
                }
            }

            //data.ForEach(row => response.Add(new SetProductResponse()
            //{
            //    Id = row.Id,
            //    Name = row.Name,
            //    Price = row.Price,
            //    Сompound = _context.SetProducts.Where(x => x.Id == row.SetProduct.Id).FirstOrDefault().Devices
            //})) ;

            return response;
        }


        public void CreateType(BrandTypeDTO typeDTO)
        {
            Models.Type NewType = new Models.Type();
            NewType.Name = typeDTO.Name;
            _context.Types.Add(NewType);
            _context.SaveChanges();
        }

        public void UpdateType(int id,string Name)
        {
            Models.Type Type = _context.Types.Where(x => x.Id == id).FirstOrDefault();
            if (Type != null)
            {
                Type.Name = Name;
                _context.Types.Update(Type);
            }
            _context.SaveChanges();
        }

        public void DeleteType(int id)
        {
            Models.Type Type = _context.Types.Where(x => x.Id == id).FirstOrDefault();
            if(Type != null)
            {
                _context.Types.Remove(Type);
            }
            _context.SaveChanges();
        }

        public List<List<DeviceResponse>> GetSoloSetProduct(SoloSetProduct soloSetProduct)
        {
            List<List<DeviceResponse>> result = new List<List<DeviceResponse>>();

            List<DeviceResponse> candidate = new List<DeviceResponse>();

            List<List<Product>> variant = new List<List<Product>>();

            for (int i = 0; i < soloSetProduct.TypeProducts.Count; i++)
            {
                if (soloSetProduct.TypeProducts[i].ProductId != null)
                {
                    Product typeDevice = _context.Products.Where(x => x.Id == soloSetProduct.TypeProducts[i].ProductId).FirstOrDefault();
                    DeviceResponse device = new DeviceResponse();
                    device.Price = typeDevice.Price;
                    device.Name = typeDevice.Name;
                    candidate.Add(device);
                }
                else
                {
                    var device = _context.Devices.Join(_context.Products,
                        d => d.ProductId,
                        p => p.Id,
                        (d, p) => new 
                        {
                            Name = p.Name,
                            TypeId = d.TypeId,
                            Price = p.Price
                        }
                        );
                   var a = device.Where(x=>x.TypeId== soloSetProduct.TypeProducts[i].TypeId&& x.Price < soloSetProduct.TypeProducts[i].Limit).ToList();
                    List<Product> product = new List<Product>();
                    foreach (var p in a)
                    {
                        product.Add(new Product
                        {
                            Name = p.Name,
                            Price = p.Price
                        });
                    }
                    //List<Product> product = _context.Products.Where(x => x.Type == "Device" && x.Price < soloSetProduct.TypeProducts[i].Limit).ToList();
                    variant.Add(product);
                }
                
            }

            Foo(variant, result, candidate, 0);
            return result;
        }

        void Foo(List<List<Product>> variant, List<List<DeviceResponse>> result,List<DeviceResponse> candidate,int index)
        {
            if (candidate.Count == 5)
            {
                result.Add(candidate);
                return;
            }
            if(index<variant.Count)
            {
                for (int i = 0; i < variant[index].Count; i++)
                {
                    List<DeviceResponse> copyCandidate = new List<DeviceResponse>(candidate);
                    Product product = variant[index][i];
                    DeviceResponse device = new DeviceResponse();
                    device.Price = product.Price;
                    device.Name = product.Name;
                    copyCandidate.Add(device);
                    Foo(variant, result, copyCandidate, index + 1);
                }
            }
            else
            {
                return;
            }
        }
    }
}
