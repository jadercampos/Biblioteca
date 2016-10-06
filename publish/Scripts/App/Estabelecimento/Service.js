app.service("estabelecimentoService", function ($http) {

    this.ListarTodos = function () {
        return $http.get("/api/Estabelecimento/ListarTodos/");
    }


    this.RetornarPorId = function (id) {
        return $http.get("/api/Estabelecimento/RetornarPorId/" + JSON.stringify(id));
    }
    this.Incluir = function (estabelecimento) {
        var response = $http({
            method: "post",
            url: "/api/Estabelecimento/Incluir/",
            data: JSON.stringify(estabelecimento),
            datatype: "json"
        });
        return response;
    }
    this.Alterar = function (estabelecimento) {
        var response = $http({
            method: "put",
            url: "/api/Estabelecimento/Alterar/",
            data: JSON.stringify(estabelecimento),
            datatype: "json"
        });
        return response;
    }
    this.Excluir = function (id) {
        var response = $http({
            method: "delete",
            url: "/api/Estabelecimento/Excluir/" + JSON.stringify(id),
            datatype: "json"
        });
        return response;
    }
  

});