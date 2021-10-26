<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="create_quiz.aspx.cs" Inherits="WebApplication1.create_quiz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
          <div class="form-row">
              <asp:Label id="lblError" EnableViewState="False" runat="server" ForeColor="red"></asp:Label>
               <div class="col-md-3 mb-3">
      <label for="validationServer01">Exam title</label>
      <input type="text" class="form-control" id="quiz_title" placeholder="Exam title" runat="server">
      <div class="valid-feedback">
        quiz title
      </div>
    </div>
                  <div class="col-md-3 mb-3">
      <label for="validationServer01">Number of questions</label>
      <input type="text" class="form-control" id="quiz_num" placeholder=" Questions Number" runat="server">
      <div class="valid-feedback">
        quiz title
      </div>
    </div>
         
                       <div class="col-md-3 mb-3">
      <label for="validationServer01">Number of mcq</label>
      <input type="text" class="form-control" id="num_mcq" placeholder="Number of mcq" runat="server">
      <div class="valid-feedback">
        quiz title
      </div>
    </div>
                             <div class="col-md-3 mb-3">
      <label for="validationServer01"> Mark of each mcq question</label>
      <input type="text" class="form-control" id="mark_mcq" placeholder="mcq mark" runat="server">
      <div class="valid-feedback">
        quiz title
      </div>
    </div>
   
    </div>
                  <div class="form-row">

                            <div class="col-md-3 mb-3">
      <label for="validationServer01">Number of Short answer</label>
      <input type="text" class="form-control" id="num_sa" placeholder="Number of Short Answer" runat="server">
      <div class="valid-feedback">
        quiz title
      </div>
                                </div>
       <div class="col-md-3 mb-3">
      <label for="validationServer01"> Mark of Short Answer</label>
      <input type="text" class="form-control" id="mark_sa" placeholder="Short Answer's mark" runat="server">
      <div class="valid-feedback">
        quiz title
      </div>
    </div>
                                                 <div class="col-md-6 mb-3">
      <label for="validationServer01"> Short Answe details </label>
      <input type="text" class="form-control" id="sa_desc" placeholder="Note" runat="server">
      <div class="valid-feedback">
        quiz title
      </div>
    </div>
                      </div>
                  <div class="form-row">

                                
                       <div class="col-md-3 mb-3">
      <label for="validationServer01"> Number of true/false</label>
      <input type="text" class="form-control" id="num_tf" placeholder="Number of t/f" runat="server">
      <div class="valid-feedback">
        quiz title
      </div>
    </div>
             
                         <div class="col-md-3 mb-3">
      <label for="validationServer01"> Mark of each t/f</label>
      <input type="text" class="form-control" id="mark_tf" placeholder=" t/f Mark" runat="server">
      <div class="valid-feedback">
        quiz title
      </div>
    </div>
          
        
                 <div class="col-md-3 mb-3">
      <label for="validationServer01">Starting Time</label>
      <input type="datetime-local" class="form-control" id="quiz_start" placeholder="Starting Time" runat="server">
      <div class="valid-feedback">
        start quiz datetime
      </div>
    </div>
                     <div class="col-md-3 mb-3">
      <label for="validationServer01"> Duration</label>
      <input type="number" class="form-control" id="quiz_end" placeholder=" Duration" runat="server">
     
    </div>
          </div>
        
       <center>   <asp:Button ID="join" runat="server" CssClass="accent-blue" BackColor="#6699FF" Text="add" class="form-control"  Height="62px" Width="224px" OnClick="add_Click" /></center>

    <hr />

        <div id="table_html" runat="server">

        </div>
    </form>
</asp:Content>
