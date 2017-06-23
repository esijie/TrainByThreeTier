<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="head.ascx.cs" Inherits="TrainByThreeTier.UI.control.head" %>

<nav style="" class="navbar navbar-default" role="navigation">
    <div class="navbar-header">
        <button type="button" class="navbar-toggle" data-toggle="collapse"
                data-target="#example-navbar-collapse">
            <span class="sr-only">切换导航</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
        </button>
        <a class="navbar-brand" href="http://www.netminer.cn"><img alt="logo" src="/images/logo.jpg" /></a>
    </div>
    <div class="collapse navbar-collapse" id="example-navbar-collapse">
        <ul class="nav navbar-nav">
            <li><a href="http://train.minerspider.com"><span class="glyphicon glyphicon-home"> 首页</span></a></li>
            <li><a href="#">.Net</a></li>
            <li><a href="#">Java</a></li>
            <li><a href="#">软件工程</a></li>
            <li class="dropdown"><a href="#">案例</a></li>
            <li><a href="#">讲座</a></li>
        </ul>
   

        <div class="navbar-form navbar-right">
            <div class="input-group">
                <input onkeypress="if (event.keyCode==13) {sBut.click();return false;}" type="text" id="searchinput" class="form-control" placeholder="搜索">
                <span id="sBut" name="sBut" class="input-group-addon btn btn-primary" onclick="Search()"><span class="glyphicon glyphicon-search"></span></span>
            </div>
        </div>
    </div>
</nav>