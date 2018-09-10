/// <reference path="../../../scripts/angular.js" />
/// <reference path="../../ebuy.js" />
eBuy

    .controller('adminCtrl', function ($scope, $window, $location, $http, adminSvc) {

        //collecting all service url as variable for reusability
        var catServiceBase = 'http://localhost:8595/odata/Categories';
        var subCatServiceBase = 'http://localhost:8595/odata/SubCategories';
        var supplierBase = 'http://localhost:8595/odata/Suppliers';
        var productBaseVm = 'http://localhost:8595/odata/VM_ProductCategory';
        var productBase = 'http://localhost:8595/odata/Products';
        var orderBase = 'http://localhost:8595/odata/Orders';
        var orderDetailsBase = 'http://localhost:8595/odata/OrderDetails';
        var subCatServiceBaseVm = 'http://localhost:8595/odata/VM_SubCategory';
        



        //preload effect
        function preloadEffect() {
            $('#wpf-loader-two').css('display', 'block');
            $('#wpf-loader-two').delay(200).fadeOut('slow');
        }

        $scope.preLoad = function () {
            preloadEffect();
        }



        //--------------- Shopping Cart -------------------------------
        $scope.cartItems = [];
        currentCart = {};
        var TotalPrice = 0;
        var TotalQuantity = 0;
        //--------------------------Decrement-------------------------------------
        $scope.Decrement = function (p) {
            preloadEffect();
            currentCart.ProductID = p.ProductID;
            currentCart.ProductName = p.ProductName;
            currentCart.SaleQuantity = 1;
            currentCart.SalePrice = p.UnitPrice;
            currentCart.pSalePrice = p.UnitPrice;

            if ($scope.cartItems.length == 0) {
                $scope.cartItems.push(currentCart);
                console.log($scope.cartItems)
            }
            else {

                if (!decheck(currentCart.ProductID, 1))
                    $scope.cartItems.push(currentCart);
                console.log($scope.cartItems)
            }
            console.log($scope.TotalPrice);

            currentCart = {};
            calculate();
        };

        var decheck = function (idn, f) {
            var found = false;
            for (var i = 0; i < $scope.cartItems.length; i++) {
                if ($scope.cartItems[i].ProductID == idn) {
                    $scope.cartItems[i].SaleQuantity -= f;
                    $scope.cartItems[i].pSalePrice = $scope.cartItems[i].SalePrice * $scope.cartItems[i].SaleQuantity;
                    found = true;
                    break;
                }
            }
            return found;
        }
        //--------------------------Increment-------------------------------------
        $scope.insertCart = function (p) {
            preloadEffect();
            currentCart.ProductID = p.ProductID;
            currentCart.ProductName = p.ProductName;
            currentCart.Picture = p.Picture1;
            currentCart.Quantity = p.Quantity;
            currentCart.SaleQuantity = 1;
            currentCart.SalePrice = p.UnitPrice;
            currentCart.pSalePrice = p.UnitPrice;

            if ($scope.cartItems.length == 0) {
                if (p.Quantity < 1) {
                    alert('Product out of stock');
                } else {
                    $scope.cartItems.push(currentCart);
                    console.log($scope.cartItems);
                }
                
            }
            else {

                if (!check(currentCart.ProductID, 1)) {
                    if (p.Quantity < 1) {
                        alert('Product out of stock');
                    } else {
                        $scope.cartItems.push(currentCart);
                        console.log($scope.cartItems);
                    }
                }
            }
            console.log($scope.TotalPrice);
            currentCart = {};
            calculate();
        };

        var check = function (idn, f) {
            var found = false;
            for (var i = 0; i < $scope.cartItems.length; i++) {
                if ($scope.cartItems[i].ProductID == idn) {
                    console.log($scope.cartItems[i].ProductID);
                    $scope.cartItems[i].SaleQuantity += f;
                    $scope.cartItems[i].pSalePrice = $scope.cartItems[i].SalePrice * $scope.cartItems[i].SaleQuantity;
                    found = true;
                    break;
                }
            }
            return found;
        }

        var calculate = function () {
            var gt = 0;
            var tm = 0;
            for (var i = 0; i < $scope.cartItems.length; i++) {
                tm += $scope.cartItems[i].SaleQuantity;
                gt += $scope.cartItems[i].pSalePrice;
            }
            $scope.TotalQuantity = tm;
            $scope.TotalPrice = gt;
            TotalPrice = gt;
            TotalQuantity = tm;
        }

        $scope.removeCart = function (p) {
            preloadEffect();
            $scope.cartItems.splice($scope.cartItems.indexOf(p), 1);
            calculate();
        };
        $scope.clearCart = function () {
            preloadEffect();
            $scope.cartItems.splice($scope.cartItems);
            calculate();
        };



        //generating pdf report

        //redirecting to report page
        $scope.gotoPdf = function () {
            $location.path('/pdfPage');
        }
        
        //downloading the pdf
        $scope.savePdfSample = function () {
            $scope.clearCart();
            var pdf = new jsPDF('p', 'pt', 'letter');
            var canvas = pdf.canvas
            canvas.height = 72 * 15;
            canvas.width = 72 * 15;
            var html = $("#pdfPrinter").html();
            //var options = {
            //    pagesplit: true
            //};

            //html2pdf(html, pdf, function (pdf) {
            //    pdf.save('orderDetails.pdf');
            //});

            var opt = {
                margin: 1,
                filename: 'Order_' + $scope.orderTrackNum + '.pdf',
                image: { type: 'jpeg', quality: 0.98 },
                html2canvas: { scale: 2 },
                jsPDF: { unit: 'in', format: 'letter', orientation: 'portrait' }
            };
            html2pdf().from(html).set(opt).save();

        } 



        //getting all item
        allSupplier();

        //getting all suppliers
        function allSupplier() {
            var Suppliers = adminSvc.get(supplierBase);
            Suppliers.then(function (result) {
                $scope.suppliers = result.data.value;
            }, function (err) {
                console.log(err);
            })
        }




        //arrays
        $scope.subMod = {};
        $scope.sup = {};
        $scope.catMod = {};
        $scope.prodMod = {};
        $scope.card = {};

        $scope.LoginPage = function () {
            $window.location.href = '/app/admin/view/Login.html';
        }

        $scope.Login = function () {
            $window.location.href = '/app/admin/view/adminDashboard.html';
        }

        //product operation
        $scope.addProduct = function () {
            preloadEffect();
            var imgPath = $('#img-uploadpro').attr('src');
            var newProd = $scope.prodMod;
            console.log(newProd);
            var Product = {
                ProductName: newProd.ProductName,
                CategoryID: newProd.CategoryID,
                SubCategoryID: newProd.SubCategoryID,
                SupplierID: newProd.SupplierID,
                UnitPrice: newProd.UnitPrice,
                OldPrice: newProd.OldPrice,
                Size: newProd.Size,
                Discount: newProd.Discount,
                UnitOnOrder: newProd.UnitOnOrder,
                ProductAvailable: newProd.ProductAvailable,
                ImageURL: newProd.ImageURL,
                OfferTitle: newProd.OfferTitle,
                ShortDescription: newProd.ShortDescription,
                LongDescription: newProd.LongDescription,
                Picture1: imgPath,
                Quantity: newProd.Quantity
            };
            var testing = adminSvc.postMethod(productBase, Product);
            testing.then(function (result) {
                allProducts();
                alert('Added');
                console.log(result);
            }, function (err) {
                alert(err);
            });
        }


        //getting all suppliers
        allProducts();
        function allProducts() {
            var Products = adminSvc.get(productBaseVm);
            Products.then(function (result) {
                $scope.products = result.data.value;
            }, function (err) {
                console.log(err);
            })
        }

        //edit product
        $scope.editProduct = function (product) {

            $('#modalEditProduct').modal('show');


            adminSvc.getById(productBase, product.ProductID)
                .then(function (result) {
                    $scope.prodMod = result;
                    var res = result.data;
                    //console.log(res);
                    $scope.prodMod = {};
                    $scope.prodMod.ProductID = res.ProductID;
                    $scope.prodMod.ProductName = res.ProductName;
                    $scope.prodMod.CategoryID = res.CategoryID;
                    $scope.prodMod.SubCategoryID = res.SubCategoryID;
                    $scope.prodMod.SupplierID = res.SupplierID;
                    $scope.prodMod.UnitPrice = res.UnitPrice;
                    $scope.prodMod.OldPrice = res.OldPrice || "0.00";
                    $scope.prodMod.Size = res.Size;
                    $scope.prodMod.Discount = res.Discount || "0.00";
                    $scope.prodMod.UnitOnOrder = res.UnitOnOrder;
                    $scope.prodMod.ProductAvailable = res.ProductAvailable;
                    $scope.prodMod.ImageURL = res.ImageURL;
                    $scope.prodMod.Quantity = res.Quantity;
                    $scope.prodMod.ShortDescription = res.ShortDescription;
                    $scope.prodMod.LongDescription = res.LongDescription;
                    $scope.prodMod.Picture1 = res.Picture1;
                }, function (err) {
                    console.log(err);
                })

        }

        //single product
        $scope.singleProduct = function (product) {
            $('#modalSingleProduct').modal('show');

            adminSvc.getById(productBaseVm, product.ProductID)
                .then(function (result) {
                    $scope.prodMod = result;
                    var res = result.data;
                    //console.log(res);
                    $scope.prodMod = {};
                    $scope.prodMod.ProductID = res.ProductID;
                    $scope.prodMod.ProductName = res.ProductName;
                    $scope.prodMod.CategoryName = res.CategoryName;
                    $scope.prodMod.SubCategoryName = res.SubCategoryName;
                    $scope.prodMod.CompanyName = res.CompanyName;
                    $scope.prodMod.UnitPrice = res.UnitPrice;
                    $scope.prodMod.OldPrice = res.OldPrice || "0.00";
                    $scope.prodMod.Size = res.Size || "NA";
                    $scope.prodMod.Discount = res.Discount || "0.00";
                    $scope.prodMod.UnitOnOrder = res.UnitOnOrder;
                    $scope.prodMod.ProductAvailable = res.ProductAvailable;
                    $scope.prodMod.ImageURL = res.ImageURL;
                    $scope.prodMod.Quantity = res.Quantity || "0";
                    $scope.prodMod.ShortDescription = res.ShortDescription || "Not set";
                    $scope.prodMod.LongDescription = res.LongDescription;
                    $scope.prodMod.Picture1 = res.Picture1;
                }, function (err) {
                    console.log(err);
                })

        }

        //Update product
        $scope.updateProduct = function () {
            preloadEffect();
            var imgPath = $('#img-uploadpro').attr('src');
            var newProd = $scope.prodMod;
            console.log(newProd);
            var Product = {
                ProductID: newProd.ProductID,
                ProductName: newProd.ProductName,
                CategoryID: newProd.CategoryID,
                SubCategoryID: newProd.SubCategoryID,
                SupplierID: newProd.SupplierID,
                UnitPrice: newProd.UnitPrice,
                OldPrice: newProd.OldPrice,
                Size: newProd.Size,
                Discount: newProd.Discount,
                UnitOnOrder: newProd.UnitOnOrder,
                ProductAvailable: newProd.ProductAvailable,
                ImageURL: newProd.ImageURL,
                Quantity: newProd.Quantity,
                OfferTitle: newProd.OfferTitle,
                ShortDescription: newProd.ShortDescription,
                LongDescription: newProd.LongDescription,
                Picture1: imgPath
            };
            adminSvc.put(productBase, newProd.ProductID, Product)
                .then(function (result) {
                    allProducts();
                    console.log('Success');
                }, function (err) {
                    console.log(err);
                })
        }

        //delete product
        $scope.deleteProd = function (product) {
            //preloadEffect();
            var id = product.ProductID;
            console.log(id);
            var sure = confirm('Are you sure want to delete this?');
            if (sure) {
                adminSvc.delete(productBase, id)
                    .then(function (result) {
                        allProducts();
                    }, function (err) {
                        console.log(err);
                    })
            }
        }


        //category operations

        $scope.addCategory = function () {
            preloadEffect();
            var imgPath = $('#img-uploadcat').attr('src');
            var newCat = $scope.catMod;
            console.log(newCat);
            var Category = {
                CategoryName: newCat.CategoryName,
                Description: newCat.Description,
                Picture: imgPath
            };
            var testing = adminSvc.postMethod(catServiceBase, Category);
            testing.then(function (result) {
                
                $location.path('/allCategory');
                allCategory();
                console.log(result);
            }, function (err) {
                alert(err);
            });
        }

        allCategory();
        function allCategory() {
            var Categories = adminSvc.get(catServiceBase);
            Categories.then(function (result) {
                $scope.categories = result.data.value;
            }, function (err) {
                console.log(err);
            });
        }

        //edit category
        $scope.editCategory = function (category) {
            preloadEffect();
            $('#modalEditCategory').modal('show');

            adminSvc.getById(catServiceBase, category.CategoryID)
                .then(function (result) {
                    $scope.catMod = result;
                    var res = result.data;
                    //console.log(sub);
                    $scope.catMod = {};
                    $scope.catMod.CategoryID = res.CategoryID;
                    $scope.catMod.CategoryName = res.CategoryName;
                    $scope.catMod.Description = res.Description;
                    $scope.catMod.Picture = res.Picture;
                }, function (err) {
                    console.log(err);
                })

        }

        //delete category
        $scope.deleteCat = function (category) {
            preloadEffect();
            var id = category.CategoryID;
            console.log(id);
            var sure = confirm('Are you sure want to delete this?');
            if (sure) {
                adminSvc.delete(catServiceBase, id)
                    .then(function (result) {
                        allCategory();
                    }, function (res) {
                        console.log(res);
                    })
            }
        }

        //Update category
        $scope.updateCategory = function () {
            preloadEffect();
            var imgPath = $('#img-uploadcat').attr('src');
            var newCat = $scope.catMod;
            console.log(newCat);
            var Category = {
                CategoryID: newCat.CategoryID,
                CategoryName: newCat.CategoryName,
                Description: newCat.Description,
                Picture: imgPath
            };
            adminSvc.put(catServiceBase, newCat.CategoryID, Category)
                .then(function (result) {
                    allCategory();
                    console.log('Success');
                }, function (err) {
                    console.log(err);
                })
        }


        //getting products under category
        $scope.getProdByCat = function (catId) {
            $http({
                method: 'GET',
                url: 'http://localhost:8595/odata/Categories(' + catId + ')/Products'
            })
                .then(function (result) {
                    $scope.prodByCat = {};
                    $scope.prodByCat = result.data.value;
                    var sinCat = result.data;
                    console.log(sinCat);
                    $scope.showCatProd = false;
                    if (result.data.value.length > 0) {
                        $scope.showCatProd = true;
                    }

                    adminSvc.getById(catServiceBase, catId)
                        .then(function (result) {
                            $scope.catMod = result;
                            var res = result.data;
                            //console.log(sub);
                            $scope.singleCategoryName = res.CategoryName;
                        }, function (err) {
                            console.log(err);
                        })

                    $location.path('/prodByCat');
                    console.log($scope.prodByCat);
                }, function (err) {
                    console.log(err);
                })
        }



        allSubCategory();

        function allSubCategory() {
            preloadEffect();
            var subCategories = adminSvc.get(subCatServiceBaseVm);
            subCategories.then(function (result) {
                $scope.subCategories = result.data.value;
            }, function (err) {
                console.log(err);
            })
        }

        //adding subcategories
        $scope.addSubCategory = function () {
            preloadEffect();
            var imgPath = $('#img-upload').attr('src');
            var newSubCat = $scope.subCatMod;
            console.log(newSubCat);
            var SubCategory = {
                SubCategoryName: newSubCat.Name,
                Description: newSubCat.Description,
                Picture: imgPath,
                CategoryID: newSubCat.CategoryID
            };
            console.log(SubCategory);
            var testing = adminSvc.postMethod(subCatServiceBase, SubCategory);
            testing.then(function (result) {
                console.log(result);
            }, function (err) {
                alert('Error');
            });
        }

        


        //delete subcategories
        $scope.deleteSubCat = function (subcategory) {
            preloadEffect();
            var id = subcategory.SubCategoryID;
            console.log(id);
            adminSvc.delete(subCatServiceBase, id)
                .then(function (result) {
                    allSubCategory();
                }, function (res) {
                    console.log('Error occured!');
                })
        }

        $scope.getSingleSubCat = function (subcategory) {
            preloadEffect();
            $('#modalSingleSubCat').modal('show');
            adminSvc.getById(subCatServiceBaseVm, subcategory.SubCategoryID)
                .then(function (result) {
                    $scope.subCatMod = result;
                    var sub = result.data;
                    console.log(sub);
                    $scope.subCatMod = {};
                    $scope.subCatMod.CategoryName = sub.CategoryName;
                    $scope.subCatMod.SubCategoryID = sub.SubCategoryID;
                    $scope.subCatMod.SubCategoryName = sub.SubCategoryName;
                    $scope.subCatMod.Description = sub.Description;
                    $scope.subCatMod.Picture = sub.Picture;
                }, function (err) {
                    console.log(err);
                })
        }
        $scope.editSubCat = function (subcategory) {
            preloadEffect();
            $('#modalEditSubCat').modal('show');

            adminSvc.getById(subCatServiceBase, subcategory.SubCategoryID)
                .then(function (result) {
                    $scope.subCatMod = result;
                    var sub = result.data;
                    console.log(sub);
                    $scope.subCatMod = {};
                    $scope.subCatMod.CategoryID = sub.CategoryID;
                    $scope.subCatMod.SubCategoryID = sub.SubCategoryID;
                    $scope.subCatMod.SubCategoryName = sub.SubCategoryName;
                    $scope.subCatMod.Description = sub.Description;
                    $scope.subCatMod.Picture = sub.Picture;
                }, function (err) {
                    console.log(err);
                })

        }

        $scope.updateSubCat = function () {
            preloadEffect();
            var imgPath = $('#img-uploadup').attr('src');
            console.log(imgPath);
            var newSubCat = $scope.subCatMod;
            console.log(newSubCat);
            var SubCategory = {
                SubCategoryID: newSubCat.SubCategoryID,
                SubCategoryName: newSubCat.SubCategoryName,
                Description: newSubCat.Description,
                Picture: imgPath,
                CategoryID: newSubCat.CategoryID
            };
            console.log(SubCategory);
            adminSvc.put(subCatServiceBase, newSubCat.SubCategoryID, SubCategory)
                .then(function (result) {
                    allSubCategory();
                    console.log('Success');
                }, function (err) {
                    console.log(err);
                    alert('Error');
                })
        }

        //code for supplier


        //adding supplier
        $scope.addSupplier = function () {
            preloadEffect();
            var newSupplier = $scope.sup;
            console.log(newSupplier);
            var Supplier = {
                CompanyName: newSupplier.CompanyName,
                ContactName: newSupplier.ContactName,
                Address: newSupplier.Address,
                Phone: newSupplier.Phone,
                Fax: newSupplier.Fax,
                Email: newSupplier.Email,
                City: newSupplier.City,
                Country: newSupplier.Country
            };
            var testing = adminSvc.postMethod(supplierBase, Supplier);
            testing.then(function (result) {
                $location.path('/suppliers');
                allSupplier();
            }, function (err) {
                alert('Error');
            });
        }





        //edit supplier
        $scope.editSupplier = function (supplier) {
            preloadEffect();
            $('#modalEditSupllier').modal('show');
            adminSvc.getById(supplierBase, supplier.SupplierID)
                .then(function (result) {
                    $scope.sup = result;
                    var supl = result.data;
                    //console.log(sub);
                    $scope.sup = {};
                    $scope.sup.SupplierID = supl.SupplierID;
                    $scope.sup.CompanyName = supl.CompanyName;
                    $scope.sup.ContactName = supl.ContactName;
                    $scope.sup.Address = supl.Address;
                    $scope.sup.Phone = supl.Phone;
                    $scope.sup.Fax = supl.Fax;
                    $scope.sup.Email = supl.Email;
                    $scope.sup.City = supl.City;
                    $scope.sup.Country = supl.Country;
                }, function (err) {
                    console.log(err);
                })

        }

        $scope.updateSupplier = function () {
            preloadEffect();
            var newSupplier = $scope.sup;
            console.log(newSupplier);
            var Supplier = {
                SupplierID: newSupplier.SupplierID,
                CompanyName: newSupplier.CompanyName,
                ContactName: newSupplier.ContactName,
                Address: newSupplier.Address,
                Phone: newSupplier.Phone,
                Fax: newSupplier.Fax,
                Email: newSupplier.Email,
                City: newSupplier.City,
                Country: newSupplier.Country
            };
            adminSvc.put(supplierBase, newSupplier.SupplierID, Supplier)
                .then(function (result) {
                    allSupplier();
                    console.log('Success');
                }, function (err) {
                    console.log(err);
                    alert(err);
                })
        }

        //delete supplier
        $scope.deleteSup = function (supplier) {
            preloadEffect();
            var id = supplier.SupplierID;
            console.log(id);
            var sure = confirm('Are you sure want to delete this?');
            if (sure) {
                adminSvc.delete(supplierBase, id)
                    .then(function (result) {
                        allSupplier();
                    }, function (res) {
                        console.log(res);
                    })
            }
        }

        //save order
        $scope.order = {};
        $scope.getOrders = function () {
            adminSvc.get(orderBase)
                .then(function (result) {
                    $scope.orders = result.data.value;
                    $location.path('/allOrders');
                }, function (err) {
                    console.log(err);
                })
        }

        $scope.saveOrderDetail = function () {
            preloadEffect();
            var newOrderData = $scope.order;
            var date = new Date();
            var orderId = 0;
            var Order = {
                OrderDate: date.getFullYear() + '-' + ('0' + (date.getMonth() + 1)).slice(-2) + '-' + ('0' + date.getDate()).slice(-2),
                GrandTotal: parseFloat(TotalPrice, 10).toFixed(2),
                GrandTotalItem: TotalQuantity,
                CustomerName: newOrderData.CustomerName,
                CustomerAddress: newOrderData.CustomerAddress,
                CustomerPhone: newOrderData.CustomerPhone,
                CustomerEmail: newOrderData.CustomerEmail
            }

            adminSvc.postMethod(orderBase, Order, null)
                .then(function (result) {
                    var ord = result.data;
                    orderId = ord.OrderId;
                    $scope.orderTrackNum = orderId;


                    for (var i = 0; i < $scope.cartItems.length; i++) {
                        var newData = $scope.cartItems[i];
                        console.log(newData);
                        var OrderDetails = {
                            ProductID: parseInt(newData.ProductID),
                            SaleQuantity: newData.SaleQuantity,
                            TotalSale: parseFloat(newData.pSalePrice, 10).toFixed(2),
                            SalePrice: parseFloat(newData.SalePrice, 10).toFixed(2),
                            OrderId: orderId
                        }
                        adminSvc.postMethod(orderDetailsBase, OrderDetails, null)
                            .then(function () {
                                adminSvc.getById(productBase, newData.ProductID)
                                    .then(function (result) {
                                        var prod = result.data;
                                        var qty = result.data.Quantity;

                                        var Pro = {
                                            ProductID: prod.ProductID,
                                            ProductName: prod.ProductName,
                                            CategoryID: prod.CategoryID,
                                            SubCategoryID: prod.SubCategoryID,
                                            SupplierID: prod.SupplierID,
                                            UnitPrice: prod.UnitPrice,
                                            OldPrice: prod.OldPrice,
                                            Size: prod.Size,
                                            Discount: prod.Discount,
                                            UnitOnOrder: prod.UnitOnOrder,
                                            ProductAvailable: prod.ProductAvailable,
                                            ImageURL: prod.ImageURL,
                                            Quantity: qty - newData.SaleQuantity,
                                            OfferTitle: prod.OfferTitle,
                                            ShortDescription: prod.ShortDescription,
                                            LongDescription: prod.LongDescription,
                                            Picture1: prod.Picture1
                                        };

                                        adminSvc.put(productBase, prod.ProductID, Pro)
                                            .then(function (result) {
                                                console.log(result.data.Quantity);
                                                allProducts();
                                                console.log('Quantity decresed');
                                            }, function (err) {
                                                console.log(err);
                                            });

                                    }, function (err) {
                                        console.log(err);
                                    })

                                //$scope.clearCart();
                            }, function (err) {
                                console.log(err);
                            })

                    }
                    //$scope.TotalQuantity = 0;
                    //$scope.TotalPrice = 0;
                    alert("Your Order Has been recieved");
                });

        }

        //redirecting to report page
        $scope.orderPage = function () {
            $location.path('/orderBill');
        }

        //payment method
        $scope.openPay = function () {
            $('#payMentModal').modal('show');
        }

        $scope.pay = function () {
            console.log($scope.order);
            console.log("Pay Function");
            //console.log($scope.model.cartItems.price);
            //console.log($scope.rate);
            console.log($scope.card);
            var expiration = $scope.card.exp_month.toString() + $scope.card.exp_year.toString();
            console.log(expiration);
            var r = {
                "createTransactionRequest": {
                    "merchantAuthentication": {
                        "name": "6UhGj85R",
                        "transactionKey": "6gXU7BrVVr5a628Y"

                    },
                    "refId": "123456",
                    "transactionRequest": {
                        "transactionType": "authCaptureTransaction",
                        "amount": 20,
                        "payment": {
                            "creditCard": {
                                "cardNumber": $scope.card.number,
                                "expirationDate": expiration,
                                "cardCode": $scope.card.cvc
                            }
                        },
                        "lineItems": {
                            "lineItem": {
                                "itemId": "1",
                                "name": $scope.order.CustomerName,
                                "description": "Cannes logo",
                                "quantity": "1",
                                "unitPrice": 20
                            }
                        },
                        "tax": {
                            "amount": "4.26",
                            "name": "level2 tax name",
                            "description": "level2 tax"
                        },
                        "duty": {
                            "amount": "8.55",
                            "name": "duty name",
                            "description": "duty description"
                        },
                        "shipping": {
                            "amount": "4.26",
                            "name": "level2 tax name",
                            "description": "level2 tax"
                        },
                        "poNumber": "456654",
                        "customer": {
                            "id": "99999456654"
                        },
                        "billTo": {
                            "firstName": $scope.order.CustomerName,
                            "lastName": "",
                            "company": "Self Ltd.",
                            "address": "Mohammadpur",
                            "city": "Dhaka",
                            "state": "",
                            "zip": "1207",
                            "country": "Bangladesh"
                        },
                        "shipTo": {
                            "firstName": $scope.order.CustomerName,
                            "lastName": "Bayles",
                            "company": "Thyme for Tea",
                            "address": "12 Main Street",
                            "city": "Pecan Springs",
                            "state": "TX",
                            "zip": "44628",
                            "country": "USA"
                        },
                        "customerIP": "192.168.1.1",
                        "transactionSettings": {
                            "setting": {
                                "settingName": "testRequest",
                                "settingValue": "false"
                            }
                        },
                        "userFields": {
                            "userField": [
                                {
                                    "name": "MerchantDefinedFieldName1",
                                    "value": "MerchantDefinedFieldValue1"
                                },
                                {
                                    "name": "favorite_color",
                                    "value": "blue"
                                }
                            ]
                        }
                    }
                }
            };
            console.log(r);
            adminSvc.postMethod('https://apitest.authorize.net/xml/v1/request.api', r, null)
                .then(function (data) {
                    console.log(data);
                    $scope.order.TransactionId = data.data.transactionResponse.transId;
                    console.log(data.data.transactionResponse.transId);
                    //$scope.model.transactionId = data.data.transactionResponse.transId;
                    //console.log($scope.transactionId);
                    console.log($scope.order);
                    //remoteCallSvc.post("http://localhost:4049/odata/Orders", null, $scope.order)
                    //    .then(function (result) {
                    //        $scope.transactionId = result.data.TransactionId;
                    //        console.log($scope.transactionId);
                    //        console.log(result);
                    //        cart.clear();
                    //        $scope.orderCreated = result.data.OrderId;
                    //        $("#payMentModal").modal("hide");
                    //        $scope.order = null;
                    //        $("#payMentModal").modal("hide");
                    //        $('body').removeClass('modal-open');
                    //        $('.modal-backdrop').remove();
                    //        $location.path("/thanks");
                    //    }, function (response) {
                    //        console.log(response);
                    //    });

                    $scope.saveOrderDetail();
                    $('#payMentModal').modal('hide');
                    $scope.gotoPdf();

                }, function (res) {
                    console.log(res);
                });

        }



    })