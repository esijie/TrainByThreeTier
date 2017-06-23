<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="TrainByThreeTier.UI.home" %>
<%@ Register Src="/UI/control/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="/UI/control/footer.ascx" TagName="bottom" TagPrefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>易思捷科技IT训练营</title>
    <link rel="stylesheet" href="/themes/css/main.css" />
    <link href="/images/logo.ico" rel="shortcut icon" type="image/x-icon" />
    <link rel="stylesheet" href="/themes/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/themes/css/font-awesome.min.css" />
    
    <script type="text/javascript" src="/scripts/third/jquery-1.8.2.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <uc1:head ID="head" runat="server" />
    <div class="content-wrapper">
    <div class="service_features" id="features">
        <div class="container">
            <div class="col-md-8 ser-fet">

                <asp:Repeater ID="listAL" runat="server">
                    <ItemTemplate>
                       <div class="row resourceList" style="margin:20px 0px;">
                        <div class="col-md-4"><img alt="" src="<%#Eval("CoverImg") %>" style="width:100%;height:140px;" /></div>
                        <div class="col-md-5 title" style="text-overflow:ellipsis; white-space:nowrap; overflow:hidden; ">
                        <a href="#" target="_blank">
                            <%#Eval("Title") %></a></div>
                        <div class="col-md-3 pDate"><%#Eval("PublishDate") %></div>
                        <div class="col-lg-8" style="color:#999;min-height:80px;"><%#Eval("Remark") %></div>
                        <div class="col-md-3"><i class="glyphicon glyphicon-user"></i> <%#Eval("Author") %> </div>
                        <div class="col-md-5 pDate"><i class="glyphicon glyphicon-comment"></i><%#Eval("CommentCount") %> <i class="glyphicon glyphicon-eye-open"></i><%#Eval("ClickCount") %></div>
                    </div>
                    </ItemTemplate>
                    </asp:Repeater>
   
                
            </div>
            <div class="col-md-3 ser-fet">
                <div class="rightNav" id="RightNav">
                    <img src="/Images/ewm.jpg" />
                    <h4 style="text-align:center;line-height:26px;">扫二维码<br/>关注“易思捷IT训练营”<br/>获取免费讲座机会</h4>
                </div>
            </div>
    </div>
</div>
</div>
    <uc2:bottom id="footer" runat="server"/>
    </form>
</body>
</html>
