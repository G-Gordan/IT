<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>

<!doctype html>
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7" lang=""> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8" lang=""> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9" lang=""> <![endif]-->
<!--[if gt IE 8]><!--> <html class="no-js" lang=""> <!--<![endif]-->
    <head>
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
        <title></title>
        <meta name="description" content="">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link rel="apple-touch-icon" href="apple-touch-icon.png">

        <link href='https://fonts.googleapis.com/css?family=Source+Sans+Pro:400,200,700,700italic|Pacifico|PT+Sans+Caption&subset=latin,latin-ext' rel='stylesheet' type='text/css'>
        <link href='https://fonts.googleapis.com/css?family=Playball|Source+Sans+Pro:400,700,700italic,200&subset=latin,latin-ext' rel='stylesheet' type='text/css'>
        <link href='https://fonts.googleapis.com/css?family=PT+Sans:400,700,700italic&subset=latin,latin-ext' rel='stylesheet' type='text/css'>
        <link href='https://fonts.googleapis.com/css?family=Montez' rel='stylesheet' type='text/css'>

        <link rel="stylesheet" href="http://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.6.3/css/font-awesome.min.css">

        <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css"> 

        <link rel="stylesheet" href="css/bootstrap.min.css">


        <!-- Product gallery -->
        <link href="css/productGallery.css" rel="stylesheet" type="text/css"/>


        <!-- Slick slider with four pics! -->
        <link href="css/slick-theme.css" rel="stylesheet" type="text/css"/>
        <link href="css/slick.css" rel="stylesheet" type="text/css"/>
        <!-- Slick end -->

        <!-- Dateicker end -->
        <link href="css/bootstrap-datetimepicker.css" rel="stylesheet" type="text/css"/>

        <!-- Slider first -->
        <link href="css/slider_main.css" rel="stylesheet" type="text/css"/>
        <link rel="stylesheet" href="css/main.css">

        <!-- Slider first -->
        <link href="css/slider_responsive.css" rel="stylesheet" type="text/css"/>
        <link href="css/responsive.css" rel="stylesheet" type="text/css"/>

        <link href="css/common.css" rel="stylesheet" type="text/css"/>

        <script src="js/vendor/modernizr-2.8.3-respond-1.4.2.min.js" type="text/javascript"></script>
    </head>
    <body>
        <header>
            <!-- Navbar top -->
            <section class="headerTop">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-5 center-block">
                            <article>
                                <address class="text-center">Adress of your restaurant</address>
                            </article>
                        </div>

                    </div>
                </div>
            </section><!--.headerTop end-->
            <!-- /navbar top -->

            <!-- Navbar -->
            <section class="header">
                <nav class="navbar navbar-default">
                    <div class="container  clearfix">
                        <!-- Brand and toggle get grouped for better mobile display -->

                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="#"><img src="img/logo.png" alt="Logo"/></a>

                        <!-- Collect the nav links, forms, and other content for toggling -->
                        <div class="collapse navbar-collapse clearfix text-center" id="bs-example-navbar-collapse-1">
                            <ul class="nav navbar-nav list-inline text-center clearfix">
                                <li><a href="index-page" class="text-uppercase">Home</a></li>
                                <li><a href="about-page" class="text-uppercase">About us</a></li>
                                <li><a href="" class="text-uppercase">Menu</a></li>
                                <li><a href="products-page" class="text-uppercase">Our product</a></li>
                            </ul>
                        </div><!-- /.navbar-collapse -->
                    </div><!-- /.container-fluid -->
                </nav>
            </section> <!--header end-->
            <!-- /navbar -->
        </header>

        <main>
            <!-- Our menu start -->
            <section class="headings first">
                <div class="container">
                    <div class="text-center">
                        <h2 class="text-center"><img src="img/decorationLeft.png" alt="decoration"/> Our Menu <img src="img/decorationRight.png" alt="decoration"/></h2>
                        <p class="text-center text-uppercase">Lorem ipsum dolor sit amet</p>
                        <img src="img/decoration.png" class="" alt="decoration line"/>
                        <p class="center-block">
                            Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                        </p>
                    </div>
                </div>
            </section>
            <!-- /Our menu end -->

			<c:forEach var="category" items="${categoryList}">
			
            <!-- menu-section start -->
            <section class="menu-section">
                <div class="container">
                    <div>
                        <article class="headingSecond">
                            <img src="${category.image}" class="center-block" alt="lunch"/>
                            <h2 class="text-center">${category.name}</h2>
                            <p class="text-center text-uppercase"><img src="img/doubleLine.png" alt="decoration"/>  ${category.description}  <img src="img/doubleLine.png" alt="decoration"/></p>
                        </article>
                    </div>

                    <article class="menuProducts">
                        <div class="row">
                  <!-- vec smo u for pelji gde je objekat category ustvari categoryList prosledjena u model iz -->
                  <!-- iz AdministrationContreoler iz metoge getProductForm -->
                  <!-- fild productsOnMainPage je lista iz klase Category i uzima cekirana jela odredjene kategorije-->
                        	<c:forEach var="product" items="${category.productsOnMainPage}">
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-xs-9 col-sm-10">
                                        <article class=" products">
                                            <p class="text-justify"><a href="#">${product.name}</a></p>
                                            <small>${product.description}</small>
                                        </article>
                                    </div>
                                    <div class="col-xs-3 col-sm-2">
                                        <article class="clearfix price">
                                            <p class="text-right">${product.price} RSD</p>
                                        </article>  
                                    </div>
                                </div>
                            </div>
                            </c:forEach>
                                               
                        </div>
                    </article>
                </div>
            </section>
            <!-- /Appetizers end -->
			
			</c:forEach>

            <!-- Five pics start -->
            <section class="fivePics">
                <div class="container-fluid">
                    <article class="clearfix">
                        <a href="#"><img src="img/fivePict1.jpg" class="img-responsive center-block" alt="Picture 1"/></a>
                    </article>
                    <article class="clearfix">
                        <a href="#"> <img src="img/fivePict2.jpg" class="img-responsive center-block" alt="Picture 2"/></a>
                    </article>
                    <article class="clearfix">
                        <a href="#"><img src="img/fivePict3.jpg" class="img-responsive center-block" alt="Picture 3"/></a>
                    </article>
                    <article class="clearfix">
                        <a href="#"> <img src="img/fivePict4.jpg" class="img-responsive center-block" alt="Picture 4"/></a>
                    </article>
                    <article class="clearfix">
                        <a href="#"><img src="img/fivePict5.jpg" class="img-responsive center-block" alt="Picture 5"/></a>
                    </article> 
                </div>
            </section>
            <!-- /Five pics end -->
        </main>
        <!-- Footer srart -->
        <footer>
            <section>
                <div class="container">
                    <a href="#"><img src="img/logoFooter.png" class="center-block" alt="logo"/></a>

                    <ul class="list-inline list-unstyled text-center">
                        <li><a href="#"><span class="fa fa-facebook" aria-hidden="true"></span></a></li>
                        <li><a href="#"><span class="fa fa-instagram" aria-hidden="true"></span></a></li>
                        <li><a href="#"><span class="fa fa-twitter" aria-hidden="true"></span></a></li>
                        <li><a href="#"><span class="fa fa-linkedin" aria-hidden="true"></span></a></li>
                        <li><a href="#"><span class="fa fa-skype" aria-hidden="true"></span></a></li>
                        <li><a href="#"><span class="fa fa-google-plus" aria-hidden="true"></span></a></li>
                    </ul>
                </div>
            </section>
            <section class="development ">
                <p class="text-center">Ovaj projekat je realizovan u okviru <a href="http://cubes.edu.rs">CUBES SCHOOL</a></p>
            </section>
        </footer>
        <!-- Footer end -->




        <script src="js/vendor/bootstrap.min.js" type="text/javascript"></script>

        <script>window.jQuery || document.write('<script src="js/vendor/jquery-1.11.2.js"><\/script>')</script>

        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
        <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>

        <script src="js/slick.js" type="text/javascript"></script>
        <script src="js/productGallery.min.js" type="text/javascript"></script>
        <script src="js/bootstrap-datetimepicker.js" type="text/javascript"></script>
        <script src="js/validator.js" type="text/javascript"></script>

        <script src="js/main.js" type="text/javascript"></script>
        <!-- Google Analytics: change UA-XXXXX-X to be your site's ID. -->
        <script>
            (function (b, o, i, l, e, r) {
                b.GoogleAnalyticsObject = l;
                b[l] || (b[l] =
                        function () {
                            (b[l].q = b[l].q || []).push(arguments)
                        });
                b[l].l = +new Date;
                e = o.createElement(i);
                r = o.getElementsByTagName(i)[0];
                e.src = '//www.google-analytics.com/analytics.js';
                r.parentNode.insertBefore(e, r)
            }(window, document, 'script', 'ga'));
            ga('create', 'UA-XXXXX-X', 'auto');
            ga('send', 'pageview');
        </script>
    </body>
</html>
