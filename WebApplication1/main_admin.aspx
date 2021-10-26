<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="main_admin.aspx.cs" Inherits="WebApplication1.main_admin" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <form id="form1" runat="server">
        <asp:Chart ID="LoginHistoryChart" runat="server" Width="652px">
            <series>
                <asp:Series Name="Series1" ChartArea="ChartArea1" Legend="Legend1" LegendText="Lecture">
                </asp:Series>
                <asp:Series ChartArea="ChartArea1" Legend="Legend1" LegendText="Stusent" Name="Series2">
                </asp:Series>
                <asp:Series ChartArea="ChartArea1" Legend="Legend1" LegendText="Admin" Name="Series3">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
            <Legends>
                <asp:Legend Name="Legend1">
                </asp:Legend>
            </Legends>
        </asp:Chart>
         <asp:Chart ID="RegisterChart" runat="server" Width="652px">
            <series>
                <asp:Series Name="Series1" ChartArea="ChartArea1" Legend="Legend1" LegendText="Lecture complete Active Account">
                </asp:Series>
                <asp:Series ChartArea="ChartArea1" Legend="Legend1" LegendText="Lecture Not Complete Active Account" Name="Series2">
                </asp:Series>
                <asp:Series ChartArea="ChartArea1" Legend="Legend1" LegendText="Student Complete Active Account" Name="Series3">
                </asp:Series>
                        <asp:Series ChartArea="ChartArea1" Legend="Legend1" LegendText="Student Not Complete Active Account" Name="Series4">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
            <Legends>
                <asp:Legend Name="Legend1">
                </asp:Legend>
            </Legends>
        </asp:Chart>
           <asp:Chart ID="ExamChart" runat="server" Width="652px">
            <series>
                <asp:Series Name="Series1" ChartArea="ChartArea1" Legend="Legend1" LegendText="Number of exam">
                </asp:Series>
           
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
            <Legends>
                <asp:Legend Name="Legend1">
                </asp:Legend>
            </Legends>
        </asp:Chart>
              <asp:Chart ID="StudentDoExamChart" runat="server" Width="652px">
            <series>
                <asp:Series Name="Series1" ChartArea="ChartArea1" Legend="Legend1" LegendText="Number of student do exam">
                </asp:Series>
           
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
            <Legends>
                <asp:Legend Name="Legend1">
                </asp:Legend>
            </Legends>
        </asp:Chart>
        <asp:Chart ID="assiementChart" runat="server" Width="652px">
            <series>
                <asp:Series Name="Series1" ChartArea="ChartArea1" Legend="Legend1" LegendText="Number of Assiement">
                </asp:Series>
           
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
            <Legends>
                <asp:Legend Name="Legend1">
                </asp:Legend>
            </Legends>
        </asp:Chart>
        <asp:Chart ID="assiementDoChart" runat="server" Width="652px">
            <series>
                <asp:Series Name="Series1" ChartArea="ChartArea1" Legend="Legend1" LegendText="Number of student do assiement">
                </asp:Series>
           
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
            <Legends>
                <asp:Legend Name="Legend1">
                </asp:Legend>
            </Legends>
        </asp:Chart>
                <asp:Chart ID="classChart" runat="server" Width="652px">
            <series>
                <asp:Series Name="Series1" ChartArea="ChartArea1" Legend="Legend1" LegendText="Number of class">
                </asp:Series>
           
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
            <Legends>
                <asp:Legend Name="Legend1">
                </asp:Legend>
            </Legends>
        </asp:Chart>
                   <asp:Chart ID="classjoinChart" runat="server" Width="652px">
            <series>
                <asp:Series Name="Series1" ChartArea="ChartArea1" Legend="Legend1" LegendText="Number of student join to class">
                </asp:Series>
           
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
            <Legends>
                <asp:Legend Name="Legend1">
                </asp:Legend>
            </Legends>
        </asp:Chart>
                           <asp:Chart ID="matChart" runat="server" Width="652px">
            <series>
                <asp:Series Name="Series1" ChartArea="ChartArea1" Legend="Legend1" LegendText="Number of materials">
                </asp:Series>
           
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
            <Legends>
                <asp:Legend Name="Legend1">
                </asp:Legend>
            </Legends>
        </asp:Chart>
                <asp:Chart ID="postChart" runat="server" Width="652px">
            <series>
                <asp:Series Name="Series1" ChartArea="ChartArea1" Legend="Legend1" LegendText="Number of post">
                </asp:Series>
           
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
            <Legends>
                <asp:Legend Name="Legend1">
                </asp:Legend>
            </Legends>
        </asp:Chart>
                 <asp:Chart ID="commentChart" runat="server" Width="652px">
            <series>
                <asp:Series Name="Series1" ChartArea="ChartArea1" Legend="Legend1" LegendText="Number of comment">
                </asp:Series>
           
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
            <Legends>
                <asp:Legend Name="Legend1">
                </asp:Legend>
            </Legends>
        </asp:Chart>
    </form>



</asp:Content>
