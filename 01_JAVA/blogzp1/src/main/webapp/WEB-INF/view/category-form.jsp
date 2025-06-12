<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form" %>
<%@ taglib prefix="sec" uri="http://www.springframework.org/security/tags" %>

<!DOCTYPE html>
<!--
This is a starter template page. Use this page to start your new project from
scratch. This page gets rid of all links and provides the needed markup only.
-->
<html lang="en">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <meta http-equiv="x-ua-compatible" content="ie=edge">

  <title>Blog Project - Category Form</title>

  <!-- Font Awesome Icons -->
  <link rel="stylesheet" href="${pageContext.request.contextPath}/plugins/fontawesome-free/css/all.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="${pageContext.request.contextPath}/dist/css/adminlte.min.css">
  <!-- Google Font: Source Sans Pro -->
  <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet">
</head>
<body class="hold-transition sidebar-mini">
<div class="wrapper">

  <!-- Navbar -->
  <nav class="main-header navbar navbar-expand navbar-white navbar-light">
    <!-- Left navbar links -->
    <ul class="navbar-nav">
      <li class="nav-item">
        <a class="nav-link" data-widget="pushmenu" href="#" role="button"><i class="fas fa-bars"></i></a>
      </li>
    </ul>

    
    <!-- Right navbar links -->
    <ul class="navbar-nav ml-auto">
        
        <!-- UBACENO: Messages Dropdown Menu -->
      <li class="nav-item dropdown">
      <!--  <li class="nav-item dropdown show">  -->
          <a class="nav-link" href="message-list">
          <!-- <a class="nav-link" href="#" aria-expanded="true"> -->
            <i class="far fa-comments"></i>
            <span class="badge badge-danger navbar-badge">${unreadedMessCount}</span>
          </a>
      </li>
    
      <!-- Messages Dropdown Menu -->
      <li class="nav-item dropdown">
        <a class="nav-link" data-toggle="dropdown" href="#">
          <i class="far fa-user"></i>
        </a>
        <div class="dropdown-menu dropdown-menu-lg dropdown-menu-right">
          <a href="user-edit-profile" class="dropdown-item">
            <!-- Message Start -->
            <div class="media align-items-center">
              <img src="${pageContext.request.contextPath}/${logedUser.photo}" alt="User Avatar" class="img-brand-50 mr-3 img-circle">
              <div class="media-body">
                <h3 class="dropdown-item-title">
                
                   ${logedUser.name} ${logedUser.surname}
                  
                </h3>
              </div>
            </div>
            <!-- Message End -->
          </a>
          <div class="dropdown-divider"></div>
          <a href="user-edit-profile" class="dropdown-item">
            <i class="fas fa-user"></i> Your Profile (username: <sec:authentication property="principal.username"/>)
          </a>
          <div class="dropdown-divider"></div>
          <a href="user-change-password" class="dropdown-item">
            <i class="fas fa-edit"></i> Change Password
          </a>
          <div class="dropdown-divider"></div>
          <a href="login.html" class="dropdown-item">

			<form:form action="${pageContext.request.contextPath}/logout">
				<i class="fas fa-sign-out-alt"></i>
				<input type="submit" value="Log Out">
			</form:form>
              
          </a>
        </div>
      </li>
    </ul>
  </nav>
  <!-- /.navbar -->

  <!-- Main Sidebar Container -->
  <aside class="main-sidebar sidebar-dark-primary elevation-4">
    <!-- Brand Logo -->
    <a href="index3.html" class="brand-link">
      <img src="${pageContext.request.contextPath}/dist/img/AdminLTELogo.png" alt="Cubes School Logo" class="brand-image img-circle elevation-3"
           style="opacity: .8">
      <span class="brand-text font-weight-light">Cubes School</span>
    </a>

    <!-- Sidebar -->
    <div class="sidebar">
      <!-- Sidebar Menu -->
      <nav class="mt-2">
        <ul class="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false">
          <!-- Add icons to the links using the .nav-icon class
               with font-awesome or any other icon font library -->

          <li class="nav-item has-treeview">
            <a href="#" class="nav-link">
              <i class="nav-icon far fa-plus-square"></i>
              <p>
                Blog
                <i class="right fas fa-angle-left"></i>
              </p>
            </a>
            <ul class="nav nav-treeview">
              <li class="nav-item">
                <a href="blog-list" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Blog List</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="blog-form" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Blog Form</p>
                </a>
              </li>
            </ul>
          </li>

          <sec:authorize access="hasRole('admin')">          
          <li class="nav-item has-treeview">
            <a href="#" class="nav-link">
              <i class="nav-icon far fa-plus-square"></i>
              <p>
                Category
                <i class="right fas fa-angle-left"></i>
              </p>
            </a>
            <ul class="nav nav-treeview">
              <li class="nav-item">
                <a href="category-list" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Category List</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="category-form" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Category Form</p>
                </a>
              </li>
            </ul>
          </li>          
          </sec:authorize>

          <sec:authorize access="hasRole('admin')">                   
          <li class="nav-item has-treeview">
            <a href="#" class="nav-link">
              <i class="nav-icon far fa-plus-square"></i>
              <p>
                Tag
                <i class="right fas fa-angle-left"></i>
              </p>
            </a>
            <ul class="nav nav-treeview">
              <li class="nav-item">
                <a href="tag-list" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Tag List</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="tag-form" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Tag Form</p>
                </a>
              </li>
            </ul>
          </li>
          </sec:authorize>

          <sec:authorize access="hasRole('admin')">                             
          <li class="nav-item has-treeview">
            <a href="#" class="nav-link">
              <i class="nav-icon far fa-plus-square"></i>
              <p>
                Slide Item
                <i class="right fas fa-angle-left"></i>
              </p>
            </a>
            <ul class="nav nav-treeview">
              <li class="nav-item">
                <a href="slideitem-list" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Slide Item List</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="slideitem-form" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Slide Item Form</p>
                </a>
              </li>
            </ul>
          </li>                      
          </sec:authorize>
          
          <li class="nav-item has-treeview">
            <a href="#" class="nav-link">
              <i class="nav-icon far fa-plus-square"></i>
              <p>
                Other
                <i class="right fas fa-angle-left"></i>
              </p>
            </a>            
            <ul class="nav nav-treeview">

               <sec:authorize access="hasRole('admin')">              
               <li class="nav-item">
                <a href="user-list" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>User List</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="user-form" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>User Form</p>
                </a>
              </li>
              </sec:authorize>

             <li class="nav-item">
                <a href="comment-list" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Comment List</p>
                </a>
              </li>
			  
			    <li class="nav-item">
                <a href="message-list" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Messages List</p>
                </a>
              </li>
			  
            </ul>
          </li>
           
        </ul>
      </nav>
      <!-- /.sidebar-menu -->
    </div>
    <!-- /.sidebar -->
    
  </aside>

  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>Category Form</h1>
          </div>
          
        </div>
      </div><!-- /.container-fluid -->
            
         <a href="go-to-front" class="col-md-6 btn btn-block bg-gradient-info btn-lg">
          Go to FRONT
        </a>

    </section>

    <!-- Main content -->
    <section class="content">
      <div class="container-fluid">
        <div class="row">
          <div class="col-md-6">
            <div class="card card-primary">
              <div class="card-header">
                <h3 class="card-title">Category Form</h3>
              </div>
              <!-- /.card-header -->
              
              <!-- form start -->
              <form:form role="form" action="category-save" modelAttribute="category">
              <form:hidden path="id"/>
              <form:hidden path="numbering"/>
              
                <div class="card-body">
                  <div class="form-group">
                    <label>Name</label>
                    <form:input path="name" type="text" class="form-control" placeholder="Enter name"/>
                  	<form:errors class="text-danger" path="name"/>
                  </div>
                  
                  <div class="form-group">
                    <label>Description</label>
                    <form:input path="description" type="text" class="form-control" placeholder="Enter description"/>
                  	<form:errors class="text-danger" path="description"/>
                  </div>
                  
                   <div class="form-group">
                    <label>Image</label>
                    <form:input path="image" type="text" class="form-control" placeholder="Enter image"/>
                  	<form:errors class="text-danger" path="image"/>
                  </div>
                                    
                  <!-- iskopirano iz index.html -->
				  <div class="custom-control custom-checkbox">
       <!-- putanja je "isOnPage", znaci da podatke ubacuje u fild "isOnPage" objekta "category" -->
                     <form:checkbox class="custom-control-input" id="customCheckbox1" path="isOnPage"/>
                     <label for="customCheckbox1" class="custom-control-label">Show on Page</label>
                   </div>
                  
                </div>
                <!-- /.card-body -->

                <div class="card-footer">
                  <button type="submit" class="btn btn-primary">Save</button>
                </div>
              </form:form>
              
              
            </div>
            <!-- /.card -->
          </div>
          <!-- /.col -->
        </div>
        <!-- /.row -->
      </div><!-- /.container-fluid -->
    </section>
    <!-- /.content -->
  </div>
  <!-- /.content-wrapper -->

  

  <!-- Main Footer -->
  <footer class="main-footer">
    <!-- To the right -->
    <div class="float-right d-none d-sm-inline">
      Java Spring & Hibernate
    </div>
    <!-- Default to the left -->
    <strong>Copyright &copy; 2025 <a href="https://cubes.edu.rs">Blog Project</a>.</strong> All rights reserved.
  </footer>
</div>
<!-- ./wrapper -->

<!-- REQUIRED SCRIPTS -->

<!-- jQuery -->
<script src="${pageContext.request.contextPath}/plugins/jquery/jquery.min.js"></script>
<!-- Bootstrap 4 -->
<script src="${pageContext.request.contextPath}/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<!-- AdminLTE App -->
<script src="${pageContext.request.contextPath}/dist/js/adminlte.min.js"></script>
</body>
</html>
