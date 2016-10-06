app.controller("livroCtrl", function ($scope, livroService) {
    $scope.divLivro = false;

    ListarTodos();
    ListarIdiomas();
    ListarCapas();
    $scope.Salvar = function () {
        debugger;
        var livro = {
            Id: $scope.livro.Id,
            Nome: $scope.livro.Nome,
            Idioma: $scope.livro.Idioma,
            Capa: $scope.livro.Capa,
            Paginas: $scope.livro.Paginas
        };
        $scope.divLivro = true;
        if ($scope.Action == "Atualizar") {
            var livroData = livroService.Alterar(livro);
            livroData.then(function (data) {
                ListarTodos();
                $scope.divLivro = false;
                if (data.status == 200) {
                    toastr["success"]("Livro Alterado com Sucesso!", "WebApiAngularJS");
                }
            }, function () {
                toastr["error"]("Erro ao Alterar Livro!", "WebApiAngularJS");
            });
        } else {
            var livroData = livroService.Incluir(livro);
            livroData.then(function (data) {
                ListarTodos();
                $scope.divLivro = false;
                if (data.status == 200) {
                    toastr["success"]("Livro Cadastrado com Sucesso!", "WebApiAngularJS");
                }
            }, function () {
                toastr["error"]("Erro ao Cadastrar Livro!", "WebApiAngularJS");
            });
        }

    }
    $scope.RetornarPorId = function (livro) {
        var livroData = livroService.RetornarPorId(livro.Id);
        livroData.then(function (_livro) {
            $scope.livro = _livro.data;
            $scope.Id = _livro.Id;
            $scope.Nome = _livro.Nome;
            $scope.Idioma = _livro.Idioma;
            $scope.Capa = _livro.Capa;
            $scope.Paginas = _livro.Paginas;
            $scope.Action = "Atualizar";
            $scope.divLivro = true;
        }, function () {
            toastr["error"]("Erro ao recuperar Livro!", "WebApiAngularJS");
        });
    }
    $scope.Excluir = function (livro) {
        var livroData = livroService.Excluir(livro.Id);
        livroData.then(function (data) {
            if (data.status = 200) {
                toastr["success"]("Livro Excluído com Sucesso!", "WebApiAngularJS");
            }
            ListarTodos();
        }, function () {
            toastr["error"]("Erro ao Excluir Livro!", "WebApiAngularJS");
        });
    }
    $scope.Cancelar = function () {
        $scope.divLivro = false;
    }
    $scope.Novo = function () {
        LimpaCampos();
        $scope.Action = "Cadastrar Novo";
        $scope.divLivro = true;
    }
    function LimpaCampos() {
        $scope.Id = "";
        $scope.Nome = "";
        //$scope.Idioma = "";
        //$scope.Capa = "";
        //$scope.Paginas = "";
    }
    function ListarTodos() {

        var livrosData = livroService.ListarTodos();

        livrosData.then(function (livro) {
            $scope.livros = livro.data;
        }, function () {
            toastr["error"]("Erro ao obter Livros!", "WebApiAngularJS");
        });

    }
    function ListarIdiomas() {

        var idiomasData = livroService.ListarIdiomas();

        idiomasData.then(function (idioma) {
            $scope.idiomas = idioma.data;

        }, function () {
            toastr["error"]("Erro ao obter Idiomas!", "WebApiAngularJS");
        });

    }
    function ListarCapas() {

        var capasData = livroService.ListarCapas();

        capasData.then(function (capa) {
            $scope.capas = capa.data;

        }, function () {
            toastr["error"]("Erro ao obter Capas!", "WebApiAngularJS");
        });

    }
});