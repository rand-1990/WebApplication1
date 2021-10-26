<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="lecture_info.aspx.cs" Inherits="WebApplication1.lecture_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        span{
  position: absolute;
  margin-left: 5px;
  height: 40px;
  display: flex;
  align-items: center;
}
        .input{
  padding-left: 25px;
}
    </style>
    <div class="container-fluid">
        <div class="row">
          <!-- left column -->
          <div class="col-md-12">
            <!-- jquery validation -->
            <div class="card card-primary">
              <div class="card-header">
                <h3 class="card-title">Teacher&nbsp; Information</small></h3>
              </div>
             <asp:Label ID="lab" class="card-title" runat="server"></asp:Label>

              <!-- /.card-header -->
              <!-- form start -->
              <form id="quickForm" method="post" runat="server">
                <div class="card-body">
                     <div class="row">
                         
                              <div class="form-group col-md-3">
                      <label for="username">username</label>
                     <span><i class="fas fa-user" aria-hidden="true"></i></span> 

                    <asp:TextBox  class="form-control input" MaxLength="30" id="username" runat="server"  placeholder="username"
										></asp:TextBox>
                  </div>
                  <div class="form-group col-md-2">
                      <label for="certificates">Education</label>
                     <span><i class="fa fa-certificate" aria-hidden="true"></i></span> 

                    <asp:TextBox  class="form-control input" MaxLength="30" id="certificate" runat="server"  placeholder="certificate"
										></asp:TextBox>
                  </div>
                  <div class="form-group col-md-2">
                    <label for="birthdate">Birthdate</label>
                   <asp:TextBox EnableViewState="False" type="date" class="form-control" MaxLength="30" id="birthdate" runat="server"  placeholder="birthdate"
										></asp:TextBox>                  </div>
     
               
                    <div class="form-group col-md-2">
                    <label for="scientific_title">Degree</label>
                        <span><i class="bi bi-capslock-fill" aria-hidden="true"></i></span>
                                        <select  id="scientific_title" name="scientific_title" class="form-control input" runat="server">
                           
            <option value="Assistant Lecturer">Assistant Lecturer</option>
            <option value="Lecturer">Lecturer</option>

            <option value="Assistant Professor">Assistant Professor</option>
            <option value="Professor">Professor</option>

        </select> 
                   
                  </div>
                           <div class="form-group col-md-3">

                    <label for="general_specialization">General specialization</label>
                               <span><i class="fas fa-filter"></i></span>
                    <asp:TextBox  class="form-control input" MaxLength="30" id="general_specialization" runat="server"  placeholder="general specialization"
										></asp:TextBox>
                  </div>
                        </div>
                                         <div class="row">

                  
                    <div class="form-group col-md-3">
                    <label for="accurate_specialization">Accurate specialization</label>
                                                       <span><i class="fas fa-seedling"></i></span>

                    <asp:TextBox  class="form-control input"  id="accurate_specialization" runat="server"  placeholder="accurate specialization"
										></asp:TextBox>
                  </div>
                    <div class="form-group col-md-3">
                    <label for="phone">Phone Number</label>
                        <span><i class="fa fa-phone" aria-hidden="true"></i></span>
                    <asp:TextBox  class="form-control input"  id="phone" runat="server"  placeholder="phone"
										></asp:TextBox>
                  </div>
                    <div class="form-group col-md-3">
                    <label for="address">Full address</label>
                        <span><i class="fa fa-location-arrow" aria-hidden="true"></i></span>
                    <asp:TextBox  class="form-control input"  id="address" runat="server"  placeholder="address"
										></asp:TextBox>
                  </div>
                      <div class="form-group col-md-3">
                    <label for="identity_ID">Identity ID</label>
                          <span><i class="fa fa-id-card" aria-hidden="true"></i></span>
                    <asp:TextBox  class="form-control input" MaxLength="30" id="identity_ID" runat="server"  placeholder="identity ID"
										></asp:TextBox>
                  </div>
                   </div>
                <!-- /.card-body scientific_title -->
                <div class="card-footer">
                   <asp:Button id="insert" text="Update" runat="server" class="btn btn-primary" OnClick="Insert_Click"/>
                </div>
                     </div>
              </form>
            </div>
            <!-- /.card -->
            </div>
          <!--/.col (left) -->
          <!-- right column -->
          <div class="col-md-6">

          </div>
          <!--/.col (right) -->
        </div>
        <!-- /.row -->
      </div><!-- /.container-fluid -->
    </section>
</asp:Content>
