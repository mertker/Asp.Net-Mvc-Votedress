using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.DataAccessLayer.EntitiyFramework;
using Votedress.DataAccessLayer;
using Votedress.DataAccessLayer.EntityFramework;
using Votedress.Entities.Modellerim.AdminUrunEkleModellerim;
using Votedress.Entities.VeritabaniModellerim;
using System.ComponentModel.DataAnnotations;

namespace Votedress.BusinessLayer
{
    public class ProductManager
    {
        private GenericUnitOfWork unitOfWork = null;

        List<Color> colors = new List<Color>()
        {

        };
        public ProductManager()
        {
            unitOfWork = new GenericUnitOfWork();

            colors = unitOfWork.Repository<Color>().List();

        }
        public bool UrunEkle(UrunEkle urun_bilgileri, Guid UserId)
        {

            string kapakResmiDosyaYolu = "resimbulunamadi.jpg";

            if (urun_bilgileri.KapakResmi != null)
            {
                Guid kapak_resmi = Guid.NewGuid();

                kapak_resmi = Guid.NewGuid();
                kapakResmiDosyaYolu = Path.GetFileName(kapak_resmi.ToString() + ".jpg");
                var yuklemeYeri = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/img/"), kapakResmiDosyaYolu);
                urun_bilgileri.KapakResmi.SaveAs(yuklemeYeri);
            }

            VotedressUser votedressUser = unitOfWork.Repository<VotedressUser>().Find(x => x.id == UserId);

            if (votedressUser != null)
            {

                Product product = new Product()
                {
                    id = Guid.NewGuid(),
                    Cost = urun_bilgileri.UrunMaliyeti,
                    IsForSale = urun_bilgileri.SatilikMi,
                    LongDescription = urun_bilgileri.UzunUrunAciklamasi,
                    Price = urun_bilgileri.UrunFiyati,
                    ProductImage = "/Content/img/" + kapakResmiDosyaYolu,
                    ShortDescription = urun_bilgileri.KisaUrunAciklamasi,
                    ModifiedDate = DateTime.Now,
                    ProductName = urun_bilgileri.UrunAdi,
                    UploadDate = DateTime.Now,
                    User=votedressUser
                };

                unitOfWork.Repository<Product>().Insert(product);

                Category category = unitOfWork.Repository<Category>().Find(x=>x.id==urun_bilgileri.KategoriId);
                

                ProductCategory productCategory = new ProductCategory()
                {
                    Category= category,
                    Product=product,
                };

                unitOfWork.Repository<ProductCategory>().Insert(productCategory);


                ProductSize productSize = new ProductSize();
                ProductColor productColor;
                ProductColorDetail productColorDetail;


                string urunResmiDosyaYolu = "resimbulunamadi.jpg";


                for (int i = 0; i < urun_bilgileri.urunIcerigi.Count; i++)
                {

                    if (urun_bilgileri.urunIcerigi[i].Beden == true)
                    {
                        if (i == 0)
                        {
                            productSize = new ProductSize()
                            {
                                Product = product,
                                Size = "S",
                            };
                        }
                        else if (i == 1)
                        {
                            productSize = new ProductSize()
                            {

                                Product = product,
                                Size = "M",
                            };
                        }
                        else if (i == 2)
                        {
                            productSize = new ProductSize()
                            {
                                Product = product,
                                Size = "L",

                            };
                        }
                        else if (i == 3)
                        {
                            productSize = new ProductSize()
                            {
                                Product = product,
                                Size = "XL",

                            };
                        }
                        else if (i == 4)
                        {
                            productSize = new ProductSize()
                            {
                                Product = product,
                                Size = "XXL",

                            };
                        }

                        unitOfWork.Repository<ProductSize>().Insert(productSize);

                        for (int j = 0; j < urun_bilgileri.urunIcerigi[i].BedenRenkleri.Count; j++)
                        {
                            productColor = new ProductColor()
                            {
                                ProductSize = productSize,
                                StockCount = urun_bilgileri.urunIcerigi[i].BedenRenkleri[j].stokAdeti,
                            };

                            unitOfWork.Repository<ProductColor>().Insert(productColor);



                            for (int z = 0; z < urun_bilgileri.urunIcerigi[i].BedenRenkleri[j].renkleri.Count; z++)
                            {

                                Color colorNameFor = ColorFind(urun_bilgileri.urunIcerigi[i].BedenRenkleri[j].renkleri[z]);
                                if (colorNameFor == null)
                                {
                                    colorNameFor = new Color()
                                    {
                                        ColorCode = urun_bilgileri.urunIcerigi[i].BedenRenkleri[j].renkleri[z],
                                        ColorName = "Tanımlanmamış renk"
                                    };

                                    unitOfWork.Repository<Color>().Insert(colorNameFor);
                                }

                                productColorDetail = new ProductColorDetail()
                                {
                                    ProductColor = productColor,
                                    Color = colorNameFor

                                };
                                unitOfWork.Repository<ProductColorDetail>().Insert(productColorDetail);

                            }

                            for (int k = 0; k < urun_bilgileri.urunIcerigi[i].BedenRenkleri[j].urunResimleri.Count; k++)
                            {

                                if (urun_bilgileri.urunIcerigi[i].BedenRenkleri[j].urunResimleri[k] != null && urun_bilgileri.urunIcerigi[i].BedenRenkleri[j].urunResimleri[k].ContentLength > 0)
                                {
                                    Guid urunResmi = Guid.NewGuid();

                                    urunResmi = Guid.NewGuid();
                                    urunResmiDosyaYolu = Path.GetFileName(urunResmi.ToString() + ".jpg");
                                    var yuklemeYeri = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/img/"), urunResmiDosyaYolu);
                                    urun_bilgileri.urunIcerigi[i].BedenRenkleri[j].urunResimleri[k].SaveAs(yuklemeYeri);


                                    ProductImageGallery productImageGallery = new ProductImageGallery()
                                    {
                                        ImagePath = "/Content/img/" + urunResmiDosyaYolu,
                                        ProductColor = productColor,
                                    };

                                    unitOfWork.Repository<ProductImageGallery>().Insert(productImageGallery);
                                }


                            }


                        }
                    }
                }
            }

            if (unitOfWork.SaveChanges() > 0)
            {
                return true;
            }

            return false;

        }




        private Color ColorFind(string v)
        {
            Color color = colors.Find(x => x.ColorCode == v);

            if (color != null)
            {
                return color;

            }

            return null;
        }

        public List<Product> UrunleriGetir(Guid Kullanici_id)
        {
            if (Kullanici_id != null)
            {

                return unitOfWork.Repository<Product>().List(x => x.User.id == Kullanici_id && x.IsForSale == true).ToList();
            }

            return null;
        }

        public List<Product> SayfalamaliUrunleriGetir(int page, int pageSize, Guid magazaId, List<int> renkId, List<Guid> kategoriId, int enDusukFiyat = 0, int enYuksekFiyat = 0)
        {
            if (magazaId != null)
            {
                List<Product> urunler = new List<Product>();

                if (enDusukFiyat == 0 && enYuksekFiyat != 0)
                {
                    urunler = unitOfWork.Repository<Product>().List(x => x.User.id == magazaId && x.Price <= enYuksekFiyat);
                }
                else if (enDusukFiyat != 0 && enYuksekFiyat == 0)
                {
                    urunler = unitOfWork.Repository<Product>().List(x => x.User.id == magazaId && x.Price >= enDusukFiyat);
                }
                else if (enDusukFiyat == 0 && enYuksekFiyat == 0)
                {
                    urunler = unitOfWork.Repository<Product>().List(x => x.User.id == magazaId);
                }
                else if (enDusukFiyat != 0 && enYuksekFiyat != 0)
                {
                    urunler = unitOfWork.Repository<Product>().List(x => x.User.id == magazaId && x.Price >= enDusukFiyat && x.Price <= enYuksekFiyat);
                }

                List<Product> arananUrunler = new List<Product>();


                bool kontrol = false;


                if (renkId != null && kategoriId != null)
                {
                    for (int i = 0; i < urunler.Count; i++)
                    {
                        kontrol = false;
                        for (int k = 0; k < urunler[i].ProductCategory.Count; k++)
                        {
                            for (int j = 0; j < kategoriId.Count; j++)
                            {
                                if (urunler[i].ProductCategory[k].Category.id == kategoriId[j])
                                {
                                    for (int q = 0; q < urunler[i].ProductSize.Count; q++)
                                    {
                                        for (int t = 0; t < urunler[i].ProductSize[q].ProductColor.Count; t++)
                                        {
                                            for (int o = 0; o < urunler[i].ProductSize[q].ProductColor[t].ProductColorDetail.Count; o++)
                                            {
                                                for (int p = 0; p < renkId.Count; p++)
                                                {
                                                    if (urunler[i].ProductSize[q].ProductColor[t].ProductColorDetail[o].Color.id == renkId[p])
                                                    {
                                                        arananUrunler.Add(urunler[i]);
                                                        kontrol = true;
                                                    }
                                                }
                                                if (kontrol == true)
                                                {
                                                    break;
                                                }
                                            }
                                            if (kontrol == true)
                                            {
                                                break;
                                            }
                                        }
                                        if (kontrol == true)
                                        {
                                            break;
                                        }
                                    }
                                }
                                if (kontrol == true)
                                {
                                    break;
                                }
                            }
                            if (kontrol == true)
                            {
                                break;
                            }
                        }
                    }
                }
                else if (renkId == null && kategoriId != null)
                {
                    for (int i = 0; i < urunler.Count; i++)
                    {
                        int sayac = 0;
                        kontrol = false;
                        sayac = 0;
                        for (int k = 0; k < urunler[i].ProductCategory.Count; k++)
                        {
                         
                            for (int j = 0; j < kategoriId.Count; j++)
                            {
                                if (urunler[i].ProductCategory[k].Category.id == kategoriId[j])
                                {
                                    sayac++;
                                }                            
                            }
                            if (sayac == kategoriId.Count)
                            {
                                arananUrunler.Add(urunler[i]);
                                break;
                            }
                        }
                    }
                }
                else if (renkId != null && kategoriId == null)
                {
                    for (int i = 0; i < urunler.Count; i++)
                    {
                        kontrol = false;
                        for (int q = 0; q < urunler[i].ProductSize.Count; q++)
                        {
                            for (int t = 0; t < urunler[i].ProductSize[q].ProductColor.Count; t++)
                            {
                                for (int o = 0; o < urunler[i].ProductSize[q].ProductColor[t].ProductColorDetail.Count; o++)
                                {
                                    for (int p = 0; p < renkId.Count; p++)
                                    {
                                        if (urunler[i].ProductSize[q].ProductColor[t].ProductColorDetail[o].Color.id == renkId[p])
                                        {
                                            arananUrunler.Add(urunler[i]);
                                            kontrol = true;
                                        }
                                    }
                                    if (kontrol == true)
                                    {
                                        break;
                                    }
                                }
                                if (kontrol == true)
                                {
                                    break;
                                }
                            }
                            if (kontrol == true)
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    arananUrunler = urunler;
                }

                return arananUrunler.ToList();
                //Skip((page - 1) * pageSize).Take(pageSize).
            }

            return null;
        }




        public List<Category> KategorileriniGetir(Guid Kullanici_id)
        {
            List<Category> kategoriler = unitOfWork.Repository<Category>().List(x => x.User.id == Kullanici_id).ToList();

            return kategoriler;
        }

        public Product UrunGetir(Guid id)
        {
            return unitOfWork.Repository<Product>().Find(x => x.id == id);
        }

        public ProductComment UruneYorumEkle(Guid urunId, Guid yorumYapanId, string yorum)
        {
            ProductComment productComment = new ProductComment()
            {
                Comment = yorum,
                CommentDate = DateTime.Now,
                VotedressUser = unitOfWork.Repository<VotedressUser>().Find(x => x.id == yorumYapanId),
                Product = unitOfWork.Repository<Product>().Find(x => x.id == urunId),
            };

            ProductComment resultProductComment = unitOfWork.Repository<ProductComment>().Insert(productComment);
            unitOfWork.SaveChanges();


            return resultProductComment;
        }

        public ProductCommentReply UrunYorumunaYorumEkle(int yorumId, Guid yorumYapanId, string yorum)
        {
            ProductCommentReply productCommentReply = new ProductCommentReply()
            {
                Comment = yorum,
                CommentDate = DateTime.Now,
                VotedressUser = unitOfWork.Repository<VotedressUser>().Find(x => x.id == yorumYapanId),
                ProdutComment = unitOfWork.Repository<ProductComment>().Find(x => x.id == yorumId)
            };

            ProductCommentReply resultProductComment = unitOfWork.Repository<ProductCommentReply>().Insert(productCommentReply);
            unitOfWork.SaveChanges();


            return productCommentReply;
        }
    }
}