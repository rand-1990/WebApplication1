<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="student_info.aspx.cs" Inherits="WebApplication1.student_info" %>

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
                <h3 class="card-title">Student Information</small></h3>
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
                  <div class="form-group col-md-3">
                    <label for="birthdate">Birthdate</label>
                   <asp:TextBox EnableViewState="False" type="date" class="form-control" MaxLength="30" id="birthdate" runat="server"  placeholder="birthdate"
										></asp:TextBox>                  </div>
     
               
                    <div class="form-group col-md-3">
                    <label for="general_specialization">Department</label>
                                                       <span><i class="fas fa-filter"></i></span>

                    <asp:TextBox  class="form-control input" MaxLength="30" id="general_specialization" runat="server"  placeholder="general specialization"
										></asp:TextBox>
                  </div>
                    <div class="form-group col-md-3">
                    <label for="accurate_specialization">Branch</label>
                                                                               <span><i class="fas fa-seedling"></i></span>

                    <asp:TextBox  class="form-control input"  id="Branch" runat="server"  placeholder="accurate specialization"
										></asp:TextBox>
                  </div>
                        </div>
                                        <div class="row">

                    <div class="form-group col-md-4">
                    <label for="phone">Phone Number</label>
                                                <span><i class="fa fa-phone" aria-hidden="true"></i></span>

                    <asp:TextBox  class="form-control input"  id="phone" runat="server"  placeholder="phone"
										></asp:TextBox>
                  </div>
                    <div class="form-group col-md-4">
                    <label for="address">Full address</label>
                                                <span><i class="fa fa-location-arrow" aria-hidden="true"></i></span>

                    <asp:TextBox  class="form-control input"  id="address" runat="server"  placeholder="address"
										></asp:TextBox>
                  </div>
                      <div class="form-group col-md-4">
                    <label for="identity_ID">Identity ID</label>
                                                    <span><i class="fa fa-id-card" aria-hidden="true"></i></span>

                    <asp:TextBox  class="form-control input" MaxLength="30" id="identity_ID" runat="server"  placeholder="identity ID"
										></asp:TextBox>
                  </div>
                                            </div>
                <!-- /.card-body scientific_title -->
                <div class="card-footer">
                   <asp:Button id="insert" text="Update" runat="server" class=" btn-primary" OnClick="insert_Click"/>
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
