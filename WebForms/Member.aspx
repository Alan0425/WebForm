
<%@ Page Title="Member Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Member.aspx.cs" Inherits="Member" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    中文姓名:<input type="text" name="cname" id="txt_cname" />
    英文姓名:<input type="text" name="ename" id="txt_ename" /><br>
    email:<input type="text" name="email" id="txt_email" />
    電話:<input type="text" name="tel" id="txt_tel" />

    <input type="button" id="get-member" value="搜尋" /><br><br>

    <table id="tblData" class="table table-striped table-bordered table-hover" cellpadding="0" cellspacing="0">
        <thead>
            <tr style="text-align: center;">
                <td>編號</td>
                <td>中文姓名</td>
                <td>英文姓名</td>
                <td>email</td>
                <td>電話</td>
                <td>身分證</td>
                <td>註冊日</td>
            </tr>
        </thead>
        <tbody id="tb_members"></tbody>
    </table>

    <script type="text/javascript">
        $(function () {
            $("#get-member").click(getMember);
        });

        function getMember() {
            var cname = $("#txt_cname").val();
            var ename = $("#txt_ename").val();
            var email = $("#txt_email").val();
            var tel = $("#txt_tel").val();
            $.ajax({
                type: "POST",
                url: "Member.aspx/getMember",
                data: "{p1: '" + cname + "', p2: '" + ename + "', p3: '" + email + "', p4: '" + tel + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    var array = JSON.parse(msg.d);
                    var style = "style='text-align:center;'";
                    $('#tb_members').html("");
                    for (var i in array) {
                        $('#tb_members').append("<tr>")
                            .append("<td " + style + ">" + array[i].id + "</td>")
                            .append("<td " + style + ">" + array[i].cname + "</td>")
                            .append("<td " + style + ">" + array[i].ename + "</td>")
                            .append("<td " + style + ">" + array[i].email + "</td>")
                            .append("<td " + style + ">" + array[i].tel + "</td>")
                            .append("<td " + style + ">" + array[i].identification + "</td>")
                            .append("<td " + style + ">" + array[i].createTime + "</td>")
                            .append("</tr>");
                    }
                }
            });
        }

    </script>
</asp:Content>
