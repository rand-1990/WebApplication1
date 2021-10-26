<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="master.aspx.cs" Inherits="WebApplication1.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
          <!-- left column -->
          <div class="col-md-12">
            <!-- jquery validation -->
            <div class="card card-primary">
              <div class="card-header">
                <h3 class="card-title">Add Class</small></h3>
              </div>
             <asp:Label ID="lab" class="card-title" runat="server"></asp:Label>

              <!-- /.card-header -->
              <!-- form start -->
              <form id="quickForm" method="post" runat="server">
                <div class="card-body">
                  <div class="form-group">
                    <label for="name">Class Name</label>
                    <input type="text" name="name" class="form-control" id="name" placeholder="class name">
                  </div>
                  <div class="form-group">
                    <label for="descr">Class Description</label>
                    <input type="text" name="descr" class="form-control" id="descr" placeholder="class description">
                  </div>
                    <div class="form-group">
                    <label for="descr">Class Color</label>
                    <input type="color" name="color" class="form-control" id="color" runat="server">
                  </div>
                </div>
                <!-- /.card-body -->
                <div class="card-footer">
                   <asp:Button id="id" text="Insert" OnClick="Add_Class" runat="server" class="btn btn-primary"/>
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
