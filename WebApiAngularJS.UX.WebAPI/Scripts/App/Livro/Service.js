app.service("livroService", function ($http) {

    this.ListarTodos = function () {
        return $http.get("/api/Livro/ListarTodos/");
    }
    this.ListarEditoras = function () {
        return $http.get("/api/Editora/ListarTodos/");
    }
    this.ListarIdiomas = function () {
        return $http.get("/api/Idioma/ListarNomes/");
    }
    this.ListarCapas = function () {
        return $http.get("/api/Capa/ListarNomes/");
    }
    this.RetornarPorId = function (id) {
        return $http.get("/api/Livro/RetornarPorId/" + JSON.stringify(id));
    }
    this.Incluir = function (livro) {
        var response = $http({
            method: "post",
            url: "/api/Livro/Incluir/",
            data: JSON.stringify(livro),
            datatype: "json"
        });
        return response;
    }
    this.Alterar = function (livro) {
        var response = $http({
            method: "put",
            url: "/api/Livro/Alterar/",
            data: JSON.stringify(livro),
            datatype: "json"
        });
        return response;
    }
    this.Excluir = function (id) {
        var response = $http({
            method: "delete",
            url: "/api/Livro/Excluir/" + JSON.stringify(id),
            datatype: "json"
        });
        return response;
    }
  

});