app.service("editoraService", function ($http) {

    this.ListarTodos = function () {
        return $http.get("/api/Editora/ListarTodos/");
    }


    this.RetornarPorId = function (id) {
        return $http.get("/api/Editora/RetornarPorId/" + JSON.stringify(id));
    }
    this.Incluir = function (editora) {
        var response = $http({
            method: "post",
            url: "/api/Editora/Incluir/",
            data: JSON.stringify(editora),
            datatype: "json"
        });
        return response;
    }
    this.Alterar = function (editora) {
        var response = $http({
            method: "put",
            url: "/api/Editora/Alterar/",
            data: JSON.stringify(editora),
            datatype: "json"
        });
        return response;
    }
    this.Excluir = function (id) {
        var response = $http({
            method: "delete",
            url: "/api/Editora/Excluir/" + JSON.stringify(id),
            datatype: "json"
        });
        return response;
    }
  

});