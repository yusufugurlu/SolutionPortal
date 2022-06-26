var PersonRoleFullName = localStorage.getItem("PersonRoleFullName");
var PersonRolePersonType = localStorage.getItem("PersonRolePersonType");
var PersonTypeName = localStorage.getItem("PersonTypeName");
var MenuList = localStorage.getItem("MenuList");
var menumsg = "";
var tmpMenuList = [];
if (PersonRoleFullName && PersonRolePersonType && PersonTypeName) {
    $("#lblFullName").text(PersonRoleFullName);
}
else {
    window.location.href = "/Login.html";
}
var dto = {
    Id: PersonRolePersonType
};

    $.ajax({
        type: "POST",
        url: "api/Menu/GetMenus",
        data: JSON.stringify(dto),// now data come in this function
        contentType: "application/json; charset=utf-8",
        crossDomain: true,
        dataType: "json",
        success: function (data, status, jqXHR) {

            if (data.StatusCode === 200) {
                localStorage.setItem("MenuList", JSON.stringify(data.Data));
                tmpMenuList = data.Data;
                data.Data.map((item) => {
                    menumsg += "<li>";
                    menumsg += " <a class='waves-effect waves-dark' href='" + item.Url + "' aria-expanded='false'><i class='ti-layout-grid2'></i><span class='hide-menu'>" + item.Name + "</span></a>";
                    menumsg += "</li>";
                });
                $("#sidebarnav").html(menumsg);
            }
        },

        error: function (jqXHR, status) {
            // error handler
            console.log(jqXHR);
            alert('fail' + status.code);
        }
    });
