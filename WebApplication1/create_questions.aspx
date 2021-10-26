<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="create_questions.aspx.cs" Inherits="WebApplication1.create_questions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script src="plugins/jquery/jquery.min.js"></script>
    <script>
        var getUrlParameter = function getUrlParameter(sParam) {
            var sPageURL = window.location.search.substring(1),
                sURLVariables = sPageURL.split('&'),
                sParameterName,
                i;

            for (i = 0; i < sURLVariables.length; i++) {
                sParameterName = sURLVariables[i].split('=');

                if (sParameterName[0] === sParam) {
                    return typeof sParameterName[1] === undefined ? true : decodeURIComponent(sParameterName[1]);
                }
            }
            return false;
        };

    </script>
 <script>


         function deleteq(d) {
             $.ajax({
                 url: '/create_questions.aspx/delete_questions',
                 data: "{'id': '" + d.value +  "'}",
                 type: "POST",
                 contentType: "application/json; charset=utf-8",
                 dataType: "text",

                 success: function (data) {

                     console.log(data);
                     data = JSON.parse(data);
                     console.log(data);
                     if (data.d == "ok")
                         document.getElementById("r" + id).remove();
                 },
                 error: function (data, status, jqXHR) { alert(jqXHR); }
             });
     }
     function printdata() {
         var divToPrint = document.getElementById("all_table");
         newWin = window.open("");
         newWin.document.write(divToPrint.outerHTML);
         newWin.print();
         newWin.close();
     }

     function deletesa(d) {
         $.ajax({
             url: '/create_questions.aspx/deletesa',
             data: "{'id': '" + d.value + "'}",
             type: "POST",
             contentType: "application/json; charset=utf-8",
             dataType: "text",

             success: function (data) {

                 console.log(data);
                 data = JSON.parse(data);
                 console.log(data);
                 if (data.d == "ok")
                     document.getElementById("r" + id).remove();
             },
             error: function (data, status, jqXHR) { alert(jqXHR); }
         });
     }
     function editmcq(d) {
         document.getElementById('editmcq').style.display = "block";
         document.getElementById('edit_question_mcq').value = document.getElementById('mcq_q_' + d.value).innerText;

         document.getElementById('edit_choice1_mcq').value = document.getElementById('mcq_ch1_' + d.value).innerText;;
         document.getElementById('edit_choice2_mcq').value = document.getElementById('mcq_ch2_' + d.value).innerText;;
         document.getElementById('edit_choice3_mcq').value = document.getElementById('mcq_ch3_' + d.value).innerText;;
         document.getElementById('edit_choice4_mcq').value = document.getElementById('mcq_ch4_' + d.value).innerText;;
         document.getElementById('edit_right_ch_mcq').value = document.getElementById('mcq_right_' + d.value).innerText;;
         document.getElementById('edit_id_mcq').value = d.value;
         document.getElementById('editmcq').scrollIntoView();

     }
     function update_mcq() {
         var id = document.getElementById('edit_id_mcq').value;
         var q = document.getElementById('edit_question_mcq').value;
         var ch1 = document.getElementById('edit_choice1_mcq').value;
         var ch2 = document.getElementById('edit_choice2_mcq').value;
         var ch3 = document.getElementById('edit_choice3_mcq').value;
         var ch4 = document.getElementById('edit_choice4_mcq').value;
         var right = document.getElementById('edit_right_ch_mcq').value;
         $.ajax({
             url: '/create_questions.aspx/update_mcq',
             data: "{'id': '" + id + "','question':'"+q+"','choice1':'"+ch1+"','choice2':'"+ch2+"','choice3':'"+ch3+"','choice4':'"+ch4+"','right':'"+right+"'}",
             type: "POST",
             contentType: "application/json; charset=utf-8",
             dataType: "text",

             success: function (data) {

                 console.log(data);
                 data = JSON.parse(data);
                 console.log(data);

                 window.location.href = "create_questions.aspx?id=" + getUrlParameter("id");
             },
             error: function (data, status, jqXHR) { alert(jqXHR); }
         });
     }
     function edittf(d) {
         document.getElementById('edittf').style.display = "block";
         document.getElementById('edit_question_tf').value = document.getElementById('tf_q_' + d.value).innerText;


         document.getElementById('edit_right_ch_tf').value = document.getElementById('tf_right_' + d.value).innerText;;
         document.getElementById('edit_id_tf').value = d.value;
         document.getElementById('edittf').scrollIntoView();

     }
     function update_tf() {
         var id = document.getElementById('edit_id_tf').value;
         var q = document.getElementById('edit_question_tf').value;
    
         var right = document.getElementById('edit_right_ch_tf').value;
         $.ajax({
             url: '/create_questions.aspx/update_tf',
             data: "{'id': '" + id + "','question':'" + q +  "','right':'" + right + "'}",
             type: "POST",
             contentType: "application/json; charset=utf-8",
             dataType: "text",

             success: function (data) {

                 console.log(data);
                 data = JSON.parse(data);
                 console.log(data);

                 window.location.href = "create_questions.aspx?id=" + getUrlParameter("id");
             },
             error: function (data, status, jqXHR) { alert(jqXHR); }
         });
     }
     function editsa(d) {
         document.getElementById('editsa').style.display = "block";
         document.getElementById('edit_question_sa').value = document.getElementById('sa_q_' + d.value).innerText;


         document.getElementById('edit_id_sa').value = d.value;
         document.getElementById('editsa').scrollIntoView();

     }
     function update_sa() {
         var id = document.getElementById('edit_id_sa').value;
         var q = document.getElementById('edit_question_sa').value;

         $.ajax({
             url: '/create_questions.aspx/update_sa',
             data: "{'id': '" + id + "','question':'" + q + "'}",
             type: "POST",
             contentType: "application/json; charset=utf-8",
             dataType: "text",

             success: function (data) {

                 console.log(data);
                 data = JSON.parse(data);
                 console.log(data);

                 window.location.href = "create_questions.aspx?id=" + getUrlParameter("id");
             },
             error: function (data, status, jqXHR) { alert(jqXHR); }
         });
     }
     $(document).ready(function () {
     $('#q_type').change(function () {
         var selected = document.getElementById('q_type').value;
         console.log(selected);
         if (selected == 1) {
             document.getElementById('mcq').style.display = "block";
             document.getElementById('sa').style.display = "none";
             document.getElementById('tf').style.display = "none";
         }
         else if (selected == 2) {
             document.getElementById('mcq').style.display = "none";
             document.getElementById('sa').style.display = "none";
             document.getElementById('tf').style.display = "block";
         }
         else if (selected == 3) {
             document.getElementById('mcq').style.display = "none";
             document.getElementById('sa').style.display = "block";
             document.getElementById('tf').style.display = "none";
         }

     });
     });

     </script>
       <form runat="server">
                <div class="col-md-12 mb-3">
      <label for="validationServer01">question type</label>
      <select class="form-control" id="q_type">
          <option value="1">mcq</option>
          <option value="2">true/false</option>
          <option value="3">short answer</option>

          </select>
      <div class="valid-feedback">
      </div>
    </div>
           <div id="mcq">
          <div class="form-row">
               <div class="col-md-12 mb-3">
      <label for="validationServer01">question</label>
      <input type="text" class="form-control" id="question" placeholder="question" runat="server">
      <div class="valid-feedback">
        question
      </div>
    </div>
                  <div class="col-md-12 mb-3">
      <label for="validationServer01">choice1</label>
      <input type="text" class="form-control" id="choice1" placeholder="choice1" runat="server">
      <div class="valid-feedback">
      </div>
    </div>
                                <div class="col-md-12 mb-3">
      <label for="validationServer01">choice2</label>
      <input type="text" class="form-control" id="choice2" placeholder="choice2" runat="server">
      <div class="valid-feedback">
      </div>
    </div>                  <div class="col-md-12 mb-3">
      <label for="validationServer01">choice3</label>
      <input type="text" class="form-control" id="choice3" placeholder="choice3" runat="server">
      <div class="valid-feedback">
      </div>
    </div>                  <div class="col-md-12 mb-3">
      <label for="validationServer01">choice4</label>
      <input type="text" class="form-control" id="choice4" placeholder="choice4" runat="server">
      <div class="valid-feedback">
      </div>
    </div>                  <div class="col-md-12 mb-3">
      <label for="validationServer01">right choice</label>
      <select class="form-control" id="right_choice" placeholder="right_ch" runat="server">
          <option value="1">choice1</option>
          <option value="2">choice2</option>
          <option value="3">choice3</option>
          <option value="4">choice4</option>

          </select>
      <div class="valid-feedback">
      </div>
    </div>

          </div>
       <center>   <asp:Button ID="join" runat="server" CssClass="accent-blue" BackColor="#6699FF" Text="add" class="form-control"  Height="62px" Width="224px" OnClick="add_Click" /></center>

    <hr />

               </div>
           <div id="tf" style="display:none">
                         <div class="col-md-12 mb-3">
      <label for="validationServer01">question</label>
      <input type="text" class="form-control" id="question_tf" placeholder="question" runat="server">
      <div class="valid-feedback">
        question
      </div>
    </div>

   <div class="col-md-12 mb-3" >
      <label for="validationServer01">right choice</label>
      <select class="form-control" id="right_tf" placeholder="right_ch" runat="server">
          <option value="1">true</option>
          <option value="2">false</option>
          
          </select>
    
                 <center>   <asp:Button ID="Button1" runat="server" CssClass="accent-blue" BackColor="#6699FF" Text="add" class="form-control"  Height="62px" Width="224px" OnClick="add_tf_Click" /></center>

           </div>
               </div>
           <div id="sa" style="display:none">
                                  <div class="col-md-12 mb-3">
      <label for="validationServer01">question</label>
      <input type="text" class="form-control" id="question_sa" placeholder="question" runat="server">
     <center>   <asp:Button ID="Button2" runat="server" CssClass="accent-blue" BackColor="#6699FF" Text="add" class="form-control"  Height="62px" Width="224px" OnClick="add_sa_Click" /></center>

      <div class="valid-feedback">
        question
      </div>
    </div>


           </div>

            <center><input type="button" onclick="printdata()" class="btn btn-primary" value="print" style="display:none"/></center>   
        <div id="table_html" runat="server">

        </div>
 <div id="editmcq" style="display:none">

               <div class="form-row">
               <div class="col-md-12 mb-3">
      <label for="validationServer01">question</label>
      <input type="text" class="form-control" id="edit_question_mcq" placeholder="edit_question_mcq" >
      <div class="valid-feedback">
        question
      </div>
    </div>
                  <div class="col-md-12 mb-3">
      <label for="validationServer01">choice1</label>
      <input type="text" class="form-control" id="edit_choice1_mcq" placeholder="edit_choice1_mcq">
      <div class="valid-feedback">
      </div>
    </div>
                                <div class="col-md-12 mb-3">
      <label for="validationServer01">choice2</label>
      <input type="text" class="form-control" id="edit_choice2_mcq" placeholder="edit_choice2_mcq" >
      <div class="valid-feedback">
      </div>
    </div>                  <div class="col-md-12 mb-3">
      <label for="validationServer01">choice3</label>
      <input type="text" class="form-control" id="edit_choice3_mcq" placeholder="edit_choice3_mcq" >
      <div class="valid-feedback">
      </div>
    </div>                  <div class="col-md-12 mb-3">
      <label for="validationServer01">choice4</label>
      <input type="text" class="form-control" id="edit_choice4_mcq" placeholder="edit_choice4_mcq">
      <div class="valid-feedback">
      </div>
    </div>                  <div class="col-md-12 mb-3">
      <label for="validationServer01">right choice</label>
      <select class="form-control" id="edit_right_ch_mcq" >
          <option value="1">choice1</option>
          <option value="2">choice2</option>
          <option value="3">choice3</option>
          <option value="4">choice4</option>

          </select>
      <div class="valid-feedback">
      </div>
    </div>

          </div>
<button type="button" onclick="update_mcq()" class='btn btn-primary' s >update</button>
    <hr />
           <input type="hidden"  class="form-control" id="edit_id_mcq"   >

     </div>
         <div id="edittf" style="display:none">
                         <div class="col-md-12 mb-3">
      <label for="validationServer01">question</label>
      <input type="text" class="form-control" id="edit_question_tf" placeholder="question" >
      <div class="valid-feedback">
        question
      </div>
    </div>

   <div class="col-md-12 mb-3" >
      <label for="validationServer01">right choice</label>
      <select class="form-control" id="edit_right_ch_tf" placeholder="right_ch" >
          <option value="1">true</option>
          <option value="2">false</option>
          
          </select>
    
<button type="button" onclick="update_tf()" class='btn btn-primary' s >update</button>
    <hr />
           <input type="hidden"  class="form-control" id="edit_id_tf"   >
           </div>
               </div>
                      <div id="editsa" style="display:none">
                                  <div class="col-md-12 mb-3">
      <label for="validationServer01">question</label>
      <input type="text" class="form-control" id="edit_question_sa" placeholder="question" >

   
    </div>

<button type="button" onclick="update_sa()" class='btn btn-primary' s >update</button>
    <hr />
           <input type="hidden"  class="form-control" id="edit_id_sa"   >
           </div>

    </form>
</asp:Content>
