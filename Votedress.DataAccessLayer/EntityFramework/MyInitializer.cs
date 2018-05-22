using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Votedress.Entities;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.DataAccessLayer.EntitiyFramework
{
    public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            List<Color> renkler = new List<Color>();

            Color beyaz = new Color()
            {
                id = 0,
                ColorName = "Beyaz",
                ColorCode = "#ffffff"
            };

            renkler.Add(beyaz);
            context.Colors.Add(beyaz);


            Color siyah = new Color()
            {
                id = 1,
                ColorName = "Siyah",
                ColorCode = "#000000"
            };

            renkler.Add(siyah);
            context.Colors.Add(siyah);

            Color yesil = new Color()
            {
                id = 2,
                ColorName = "Yeşil",
                ColorCode = "#008000"
            };

            renkler.Add(yesil);
            context.Colors.Add(yesil);

            Color kirmizi = new Color()
            {
                id = 3,
                ColorName = "Kirmizi",
                ColorCode = "#ff0000"
            };

            renkler.Add(kirmizi);
            context.Colors.Add(kirmizi);

            Color sari = new Color()
            {
                id = 4,
                ColorName = "Sarı",
                ColorCode = "#ffff00"
            };

            renkler.Add(sari);
            context.Colors.Add(sari);




            City adana = new City()
            {
                CityID = 1,
                CountryID = 212,
                CityName = "ADANA",
                PlateNo = 1,
                PhoneCode = 322

            };
            context.Cities.Add(adana);

            County aladag = new County()
            {
                CountyID = 1,
                City = adana,
                CountyName = "ALADAĞ",
            };
            context.Counties.Add(aladag);

            Area aladag_area = new Area()
            {
                AreaID = 1,
                County = aladag,
                AreaName = "ALADAĞ"
            };
            context.Areas.Add(aladag_area);
            Neighborhood akpinar_mah = new Neighborhood()
            {
                Area = aladag_area,
                NeighborhoodID = 1,
                NeighborhoodName = "AKPINAR MAH.",
                ZipCode = "01720"
            };
            context.Neighborhoods.Add(akpinar_mah);
            Neighborhood baspinar_mah = new Neighborhood()
            {
                Area = aladag_area,
                NeighborhoodID = 2,
                NeighborhoodName = "BAŞPINAR MAH.",
                ZipCode = "123312"
            };
            context.Neighborhoods.Add(baspinar_mah);
            Neighborhood mansurlu_mah = new Neighborhood()
            {
                Area = aladag_area,
                NeighborhoodID = 3,
                NeighborhoodName = "MANSURLU MAH.",
                ZipCode = "123312"
            };
            context.Neighborhoods.Add(mansurlu_mah);

            City adiyaman = new City()
            {
                CityID = 2,
                CountryID = 212,
                CityName = "ADIYAMAN",
                PlateNo = 2,
                PhoneCode = 416

            };
            context.Cities.Add(adiyaman);

            County besni = new County()
            {
                CountyID = 16,
                City = adiyaman,
                CountyName = "BESNİ",
            };
            context.Counties.Add(besni);
            Area besni_area = new Area()
            {
                AreaID = 71,
                County = besni,
                AreaName = "BESNİ"
            };
            context.Areas.Add(besni_area);
            Neighborhood asagisarhan_mah = new Neighborhood()
            {
                Area = besni_area,
                NeighborhoodID = 831,
                NeighborhoodName = "AŞAĞISARHAN MAH.",
                ZipCode = "01720"
            };
            context.Neighborhoods.Add(asagisarhan_mah);
            Neighborhood cat_mah = new Neighborhood()
            {
                Area = besni_area,
                NeighborhoodID = 832,
                NeighborhoodName = "ÇAT MAH.",

            };
            context.Neighborhoods.Add(cat_mah);
            context.SaveChanges();


            VotedressUser ornek_kullanici1 = new VotedressUser()
            {

                SocialId = null,
                Email = "mert.igdir@hotmail.com ",
                Password = "5fa016gs",
                Role = "sahis",
                IsActive = true,
                ActivateGuid = Guid.NewGuid(),
                ProfileImage = "/Content/img/profil_resmi.png",
                SocialName = "votedress",
                CreateDate = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now)
            };

            context.VotedressUsers.Add(ornek_kullanici1);
            context.SaveChanges();

            UserDetail ornek_kullanici1_detail = new UserDetail()
            {

                UserId = ornek_kullanici1.id,
                Birthday = DateTime.Now,
                County = null,
                Name = "Mert",
                SurName = "İGDİR",
                City = null,
                Sex = "erkek",
                Neighborhood = null


            };

            context.UserDetail.Add(ornek_kullanici1_detail);

            context.SaveChanges();




            Guid ornek_kullanici2_guid = Guid.NewGuid();

            VotedressUser ornek_kullanici2 = new VotedressUser()
            {

                SocialId = null,
                Email = "mert.igdir@hotmeil.com ",
                Password = "5fa016gs",
                Role = "sahis",
                IsActive = true,
                ActivateGuid = Guid.NewGuid(),
                ProfileImage = "/Content/img/profil_resmi.png",
                SocialName = "votedress",
                CreateDate = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now)
            };

            context.VotedressUsers.Add(ornek_kullanici2);
            context.SaveChanges();


            UserDetail ornek_kullanici2_detail = new UserDetail()
            {

                UserId = ornek_kullanici2.id,
                Birthday = DateTime.Now,
                County = null,
                Name = "Erdem",
                SurName = "KESKİN",
                City = null,
                Sex = "erkek",
                Neighborhood = null


            };

            context.UserDetail.Add(ornek_kullanici2_detail);

            context.SaveChanges();

            for (int i = 0; i < 1; i++)
            {
                Franchise franchise = new Franchise()
                {
                    FranchiseName = FakeData.NameData.GetCompanyName(),
                    FranchiseLogo = "/Content/img/franchiseLogo.png",
                    IsActivated = true,
                    CreateDate = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now)

                };

                franchise = context.Franchises.Add(franchise);
                context.SaveChanges();

                for (int j = 0; j < 2; j++)
                {
                    VotedressUser magaza = new VotedressUser()
                    {
                        SocialId = null,
                        Email = FakeData.NetworkData.GetEmail(),
                        Password = "123123",
                        Role = "kurumsal",
                        IsActive = true,
                        ActivateGuid = Guid.NewGuid(),
                        ProfileImage = "/Content/img/magazaLogo.png",
                        SocialName = "votedress",
                        CreateDate = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        OnlineCount = 0,
                        Franchise = franchise,

                    };

                    magaza = context.VotedressUsers.Add(magaza);
                    context.SaveChanges();

                    City sehir = new City();
                    County ilce = new County();
                    Neighborhood mahalle = new Neighborhood();

                    if (FakeData.NumberData.GetNumber(0, 2) == 0)
                    {
                        sehir = adana;
                        ilce = aladag;
                        int random = FakeData.NumberData.GetNumber(0, 3);
                        if (random == 0)
                        {
                            mahalle = akpinar_mah;
                        }
                        else if (random == 1)
                        {
                            mahalle = baspinar_mah;
                        }
                        else if (random == 2)
                        {
                            mahalle = mansurlu_mah;
                        }

                    }
                    else
                    {
                        sehir = adiyaman;
                        ilce = besni;
                        int random = FakeData.NumberData.GetNumber(0, 2);
                        if (random == 0)
                        {
                            mahalle = asagisarhan_mah;
                        }
                        else if (random == 1)
                        {
                            mahalle = cat_mah;
                        }

                    }


                    UserDetail magaza_detail = new UserDetail()
                    {
                        UserId = magaza.id,
                        Birthday = DateTime.Now,
                        County = ilce,
                        Name = "Mert",
                        SurName = "İGDİR",
                        City = sehir,
                        Sex = "erkek",
                        CommencialTitle = FakeData.NameData.GetFirstName(),
                        CompanyName = FakeData.NameData.GetCompanyName(),
                        AdressDetail = FakeData.PlaceData.GetAddress(),
                        LandPhone = FakeData.PhoneNumberData.GetPhoneNumber(),
                        PhoneNumber = FakeData.PhoneNumberData.GetPhoneNumber(),
                        Neighborhood = mahalle
                    };

                    context.UserDetail.Add(magaza_detail);
                    context.SaveChanges();

                    List<Category> kategoriler = new List<Category>();

                    for (int z = 0; z < 2; z++)
                    {
                        Category kategori = new Category()
                        {
                            id = Guid.NewGuid(),
                            User = magaza,
                            CategoryName = FakeData.NameData.GetFullName(),
                            Description = FakeData.TextData.GetSentences(3),
                            CreateDate = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now)

                        };
                        kategoriler.Add(kategori);

                        context.Categories.Add(kategori);
                    }

                    for (int t = 0; t < 3; t++)
                    {
                        Product urun = new Product()
                        {
                            id = Guid.NewGuid(),
                            Price = FakeData.NumberData.GetNumber(20, 1000),
                            IsForSale = true,
                            LongDescription = FakeData.TextData.GetSentences(5),
                            ModifiedDate = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ProductImage = "/Content/img/Product.jpg",
                            ProductName = FakeData.NameData.GetFullName(),
                            ShortDescription = FakeData.TextData.GetSentences(2),
                            UploadDate = DateTime.Now,
                            User = magaza,
                        };

                        context.Products.Add(urun);



                        for (int n = 0; n < 2; n++)
                        {
                            int random = FakeData.NumberData.GetNumber(0, 2);
                            ProductCategory productCategory = new ProductCategory()
                            {
                                Product = urun,
                                Category = kategoriler[random]
                            };

                            context.ProductCategories.Add(productCategory);
                        }
                        context.SaveChanges();

                        for (int p = 0; p < 5; p++)
                        {
                            ProductSize productSize = new ProductSize();

                            switch (p)
                            {
                                case 0:
                                    productSize.Product = urun;
                                    productSize.Size = "S";
                                    break;
                                case 1:
                                    productSize.Product = urun;
                                    productSize.Size = "M";
                                    break;
                                case 2:
                                    productSize.Product = urun;
                                    productSize.Size = "L";
                                    break;
                                case 3:
                                    productSize.Product = urun;
                                    productSize.Size = "XL";
                                    break;
                                case 4:
                                    productSize.Product = urun;
                                    productSize.Size = "XXL";
                                    break;
                            }

                            context.ProductSizes.Add(productSize);


                            for (int w = 0; w < 3; w++)
                            {

                                ProductColor productColor = new ProductColor()
                                {
                                    ProductSize = productSize,
                                    StockCount = FakeData.NumberData.GetNumber(10, 100),
                                };
                                context.ProductColors.Add(productColor);

                                for (int z = 0; z < 2; z++)
                                {
                                    int random = FakeData.NumberData.GetNumber(0, 5);
                                    ProductColorDetail productColorDetail = new ProductColorDetail()
                                    {
                                        ProductColor = productColor,
                                        Color = renkler[random],
                                    };

                                    context.ProductColorDetails.Add(productColorDetail);
                                }

                                for (int q = 0; q < 3; q++)
                                {
                                    ProductImageGallery imageGallery = new ProductImageGallery()
                                    {
                                        ProductColor = productColor,
                                        ImagePath = "/Content/img/Product.jpg",

                                    };

                                    context.ProductImageGallery.Add(imageGallery);
                                }
                            }
                        }
                        context.SaveChanges();
                    }

                }
                context.SaveChanges();
            }



            List<Product> products = context.Products.ToList();



            for (int i = 0; i < 10; i++)
            {
                VotedressUser ornek_kullanici = new VotedressUser()
                {
                    SocialId = null,
                    Email = FakeData.NetworkData.GetEmail(),
                    Password = "123123",
                    Role = "sahis",
                    IsActive = true,
                    ActivateGuid = Guid.NewGuid(),
                    ProfileImage = "/Content/img/profil_resmi.png",
                    SocialName = "votedress",
                    CreateDate = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now)
                };


                context.VotedressUsers.Add(ornek_kullanici);
                context.SaveChanges();


                UserDetail ornek_kullanici_personal = new UserDetail()
                {

                    UserId = ornek_kullanici.id,
                    Birthday = DateTime.Now,
                    County = null,
                    Name = FakeData.NameData.GetFirstName(),
                    SurName = FakeData.NameData.GetSurname(),
                    City = null,
                    Sex = (i % 2 == 0) ? "erkek" : "kadın",
                    Neighborhood = null

                };

                context.UserDetail.Add(ornek_kullanici_personal);
                context.SaveChanges();

                bool arkDurum = FakeData.BooleanData.GetBoolean();

                Friend arkadas3 = new Friend()
                {
                    User = ornek_kullanici1,
                    MyFriend = ornek_kullanici,
                    ArkadaslikTarihi = DateTime.Now,
                    Durum= arkDurum

                };

                context.Friends.Add(arkadas3);
                context.SaveChanges();

                Vote oylama = new Vote()
                {
                    id = Guid.NewGuid(),
                    Counter = 0,
                    FinishTime = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(+1), DateTime.Now.AddDays(+1)),
                    PaylasimaAcikmi = true,
                    ProfilGorunsunMu = true,
                    StartTime = DateTime.Now,
                    TypeOfVote = "genel",
                    VoteLink = Guid.Empty,
                    User = ornek_kullanici
                };

                context.Votes.Add(oylama);
      

                for(int l=0;l<3;l++)
                {
                    VoteProduct voteProduct = new VoteProduct()
                    {

                        Product = products[FakeData.NumberData.GetNumber(0, products.Count)],
                        Vote = oylama,
                        VoteCount=FakeData.NumberData.GetNumber(10,10000),

                    };
                    context.VoteProduct.Add(voteProduct);


                    for (int k = 0; k < 2; k++)
                    {
                        VoteImage oylamaResmi = new VoteImage()
                        {
                            ImageNo = k + 1,
                            Aciklama = FakeData.TextData.GetSentences(1),
                            VoteProduct = voteProduct,
                            ImagePath = "/Content/img/4b90ffac-1ad2-e711-851d-80fa5b102e43_bc040459-cd97-47ef-aedf-bc177ab069f6_1.jpg",

                        };

                        context.VoteImages.Add(oylamaResmi);
                        context.SaveChanges();
                    }
                }

                context.SaveChanges();



            }

            context.SaveChanges();



            OnlineUser onlineler = new OnlineUser()
            {

                ConnectionId = Guid.NewGuid().ToString(),
                UserId = ornek_kullanici1.id,
                OnlineOlmaTarihi = DateTime.Now,
                Disconnected = "reflesh"


            };

            context.OnlineUsers.Add(onlineler);
            context.SaveChanges();

            OnlineUser onlineler2 = new OnlineUser()
            {

                ConnectionId = Guid.NewGuid().ToString(),
                UserId = ornek_kullanici2.id,
                OnlineOlmaTarihi = DateTime.Now

            };

            context.OnlineUsers.Add(onlineler2);
            context.SaveChanges();



            Friend arkadas = new Friend()
            {
                User = ornek_kullanici1,
                MyFriend = ornek_kullanici2,
                ArkadaslikTarihi = DateTime.Now,
                Durum=true
                

            };

            context.Friends.Add(arkadas);
            context.SaveChanges();



            Friend arkadas2 = new Friend()
            {
                User = ornek_kullanici2,
                MyFriend = ornek_kullanici1,
                ArkadaslikTarihi = DateTime.Now,
                Durum = true

            };

            context.Friends.Add(arkadas2);
            context.SaveChanges();



            VotedressUser kullanici = context.VotedressUsers.Where(x => x.Email == "mert.igdir@hotmail.com").FirstOrDefault();

            List<Friend> arkdaslar = context.Friends.Where(x => x.User.id == kullanici.id).ToList();


            PrivateMessage mesaj = null;

            for (int i = 0; i < arkdaslar.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    mesaj = new PrivateMessage()
                    {
                        User = kullanici,
                        AlanId = arkdaslar[i].MyFriend,
                        GorulmeDurumu = true,
                        GöndermeTarihi = DateTime.Now,
                        Message = FakeData.TextData.GetSentences(2)

                    };

                    context.PrivateMessages.Add(mesaj);
                    context.SaveChanges();

                    mesaj = new PrivateMessage()
                    {
                        User = arkdaslar[i].MyFriend,
                        AlanId = kullanici,
                        GorulmeDurumu = true,
                        GöndermeTarihi = DateTime.Now,
                        Message = FakeData.TextData.GetSentences(2)

                    };

                    context.PrivateMessages.Add(mesaj);
                    context.SaveChanges();
                }
            }


            List<Vote> votes = context.Votes.ToList();
            List<Collection> collections = context.Collections.ToList();
            List<VotedressUser> users = context.VotedressUsers.Where(x => x.Role == "sahis").ToList();
            List<Vote> vote = context.Votes.ToList();

            string[] socials = { "facebook", "instagram", "twitter", "votedress" };



            for (int k = 0; k < users.Count; k++)
            {

                for (int i = 0; i < 5; i++)
                {

                    ProductComment productComment = new ProductComment()
                    {
                        Product = products[FakeData.NumberData.GetNumber(0, products.Count)],
                        CommentDate = DateTime.Now,
                        Comment = "yorum "+i+" "+ FakeData.TextData.GetSentences(3),
                        VotedressUser = users[k],
                    };

                    context.ProductComments.Add(productComment);

                    for (int z = 0; z < 3; z++)
                    {
                        ProductCommentLike productCommentLike = new ProductCommentLike()
                        {
                            LikeDate = DateTime.Now,
                            VotedressUser = users[z],
                            ProductComment = productComment,
                        };

                        context.ProductCommentLike.Add(productCommentLike);
                       
                    }

                    for (int t = 0; t < 5; t++)
                    {
                        ProductCommentReply productCommentReply = new ProductCommentReply()
                        {
                            ProdutComment = productComment,
                            Comment = "cevap " + i + " " + FakeData.TextData.GetSentences(2),
                            CommentDate = DateTime.Now,
                            VotedressUser = users[FakeData.NumberData.GetNumber(0, users.Count)],
                        };

                        context.ProductCommentReplies.Add(productCommentReply);


                        for (int z = 0; z < 3; z++)
                        {
                            ProductCommentReplyLike productCommentReplyLike = new ProductCommentReplyLike()
                            {
                                LikeDate = DateTime.Now,
                                VotedressUser = users[users.Count-z],
                                ProductCommentReply = productCommentReply,
                            };

                            context.ProductCommentReplyLikes.Add(productCommentReplyLike);

                        }
                    }
                }
            }

            context.SaveChanges();

            string[] share = { "vote", "product", "collection" };

            for (int i = 0; i < users.Count; i++)//Paylaşım tablosuna test verileri eklendi
            {
                for (int j = 0; j < 5; j++)
                {

                    SocialShare socialShare = new SocialShare()
                    {
                        id = Guid.NewGuid(),
                        VotedressUser = users[i],
                        ShareDate = DateTime.Now,
                        SocialName = socials[FakeData.NumberData.GetNumber(0, 4)],

                    };

                    switch (FakeData.NumberData.GetNumber(0, 3))
                    {
                        case 0:
                            socialShare.ShareName = share[0];
                            socialShare.Vote = vote[FakeData.NumberData.GetNumber(0, vote.Count)];
                            break;
                        case 1:
                            socialShare.ShareName = share[1];
                            socialShare.Product = products[FakeData.NumberData.GetNumber(0, products.Count)];
                            break;
                        case 2:
                            socialShare.ShareName = share[2];
                            socialShare.Collection = collections[FakeData.NumberData.GetNumber(0, collections.Count)];
                            break;
                    }

                    context.SocialShares.Add(socialShare);
                }
            }
            context.SaveChanges();

        }
    }
}

