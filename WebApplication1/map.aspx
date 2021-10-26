<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="map.aspx.cs" Inherits="WebApplication1.map" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
<script type="text/javascript">
var markers = [
<asp:Repeater ID="rptMarkers" runat="server">
<ItemTemplate>
            {
            "title": '<%# Eval("username") %>',
            "lat": '<%# Eval("lat") %>',
            "lng": '<%# Eval("long") %>',
            "description": '<%# Eval("username") %>'
        }
</ItemTemplate>
<SeparatorTemplate>
    ,
</SeparatorTemplate>
</asp:Repeater>
];
</script>
<script type="text/javascript">
    window.onload = function () {
        var mapOptions = {
            center: new google.maps.LatLng(markers[0].lat, markers[0].lng),
            zoom: 8,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var infoWindow = new google.maps.InfoWindow();
        var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);
        var dtlat=[];
        var dtlong=[];
        for (i = 0; i < markers.length; i++) {
            var data = markers[i]
            if (dtlong.indexOf(data.lng) == -1 && dtlat.indexOf(data.lat) == -1) {
                dtlat[i] = data.lat;
                dtlong[i] = data.lng;
            }
            else {

                data.lat = parseFloat(data.lat) + (Math.random() - .5) / 1500;
                data.lng = parseFloat(data.lng) + (Math.random() - .5) / 1500;
            }
            this.console.log("lat"+data.lat+"  lang="+data.lng)
            var myLatlng = new google.maps.LatLng(data.lat, data.lng);
            var marker = new google.maps.Marker({
                position: myLatlng,
                map: map,
                title: data.title,
                label: {
                    text: data.title,
                    color: "white",
                    fontWeight: "bold",
                    fontSize: "16px"
                }
            });
            (function (marker, data) {
                google.maps.event.addListener(marker, "click", function (e) {
                    infoWindow.setContent(data.description);
                    infoWindow.open(map, marker);
                });
            })(marker, data);
        }
    }
</script>
<div id="dvMap" style=" height: 1000px">
</div>

</asp:Content>
