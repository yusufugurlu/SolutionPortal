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
                try {
                    if (item.ChildMenu.length > 0) {
                        menumsg += "<li><a class='has-arrow waves-effect waves-dark' href='javascript:void(0)' aria-expanded='false'><i class='icon-speedometer'></i><span class='hide-menu'> " + item.Name + "</span ></a> ";
                        menumsg += "<ul aria-expanded='false' class='collapse'>";
                        item.ChildMenu.map((item) => {
                            menumsg += "<li><a href='" + item.Url + "'> " + item.Name + "</a></li>";
                        });
                        menumsg += "</ul>";
                        menumsg += "</li>";
                    }
                    else {
                        menumsg += "<li>";
                        menumsg += " <a class='waves-effect waves-dark' href='" + item.Url + "' aria-expanded='false'><i class='ti-layout-grid2'></i><span class='hide-menu'>" + item.Name + "</span></a>";
                        menumsg += "</li>";
                    }
                } catch (e) {
                    menumsg += "<li>";
                    menumsg += " <a class='waves-effect waves-dark' href='" + item.Url + "' aria-expanded='false'><i class='ti-layout-grid2'></i><span class='hide-menu'>" + item.Name + "</span></a>";
                    menumsg += "</li>";
                }

            });
            console.log(menumsg);
            $("#sidebarnav").html(menumsg);
        }
    },

    error: function (jqXHR, status) {
        // error handler
        console.log(jqXHR);
        alert('fail' + status.code);
    }
});
