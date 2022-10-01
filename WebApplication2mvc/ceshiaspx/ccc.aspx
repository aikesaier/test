<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ccc.aspx.cs" Inherits="WebApplication2mvc.ceshiaspx.ccc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <%Response.Write("ddd踩踩踩踩踩踩踩踩踩踩踩踩ddd");
                    string username = Request.QueryString["username"];
                    Response.Write(username);
                    %>
            士大夫士大夫十分
        </div>
    </form>
</body>
</html>
