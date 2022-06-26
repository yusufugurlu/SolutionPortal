$("#btnLogin").click(function () {
    var username = $("#txtUserName").val();
    var pass = $("#txtPassword").val();
    var dto = {
        UserName: username,
        Password: pass
    };
    $("#btnLogin").prop("disabled", true);
    $.ajax({
        type: "POST",
        url: "api/Person/Login",
        data: JSON.stringify(dto),// now data come in this function
        contentType: "application/json; charset=utf-8",
        crossDomain: true,
        dataType: "json",
        success: function (data, status, jqXHR) {

            if (data.StatusCode === 200) {
                localStorage.setItem("PersonRoleFullName", data.Data.FullName);
                localStorage.setItem("PersonRolePersonType", data.Data.PersonType);
                localStorage.setItem("PersonTypeName", data.Data.PersonTypeName);

                window.location.href = "/Index.html";
            }
            else {
                alert(data.Message);
            }
            $("#btnLogin").prop("disabled", false);
        },

        error: function (jqXHR, status) {
            // error handler
            alert('fail' + status.code);
            $("#btnLogin").prop("disabled", false);
        }
    });
});


$("#btnLogOut").click(function () {
    localStorage.removeItem("PersonRoleFullName");
    localStorage.removeItem("PersonRolePersonType");
    localStorage.removeItem("PersonTypeName");
    localStorage.removeItem("MenuList");
    window.location.href = "/Login.html";

});