app.controller("livroCtrl", function ($scope, livroService) {
    $scope.divLivro = false;

    ListarTodos();
    ListarIdiomas();
    ListarCapas();
    ListarEditoras();
    $scope.Salvar = function () {
        debugger;
        var livro = {
            Id: $scope.livro.Id,
            Editora: $scope.livro.Editora,
            Nome: $scope.livro.Nome,
            Idioma: $scope.livro.Idioma,
            Capa: $scope.livro.Capa,
            Paginas: $scope.livro.Paginas,
            DtInc: $scope.livro.DtInc,
            DtAlt: $scope.livro.DtAlt
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
            $scope.Editora = _livro.Editora;
            $scope.Nome = _livro.Nome;
            $scope.Idioma = _livro.Idioma;
            $scope.Capa = _livro.Capa;
            $scope.Paginas = _livro.Paginas;
            $scope.DtInc = _livro.DtInc;
            $scope.DtInc = _livro.DtAlt;
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
        if ($scope.livro) {
            $scope.livro.Id = "";
            $scope.livro.Editora = "";
            $scope.livro.Nome = "";
            $scope.livro.Idioma = "";
            $scope.livro.Capa = "";
            $scope.livro.Paginas = "";
            $scope.livro.DtInc = "";
            $scope.livro.DtAlt = "";
        }
    }
    function ListarTodos() {

        var livrosData = livroService.ListarTodos();

        livrosData.then(function (livro) {
            $scope.livros = livro.data;
        }, function () {
            toastr["error"]("Erro ao obter Livros!", "WebApiAngularJS");
        });

    }
    function ListarEditoras() {

        var editoraData = livroService.ListarEditoras();

        editoraData.then(function (editora) {
            $scope.editoras = editora.data;
        }, function () {
            toastr["error"]("Erro ao obter Editoras!", "WebApiAngularJS");
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