app.controller("estabelecimentoCtrl", function ($scope, estabelecimentoService) {

    $scope.divEstabelecimento = false;

    ListarTodos();
    $scope.Salvar = function () {
        debugger;
        var estabelecimento = {
            Id: $scope.estabelecimento.Id,
            Nome: $scope.estabelecimento.Nome,
            Descricao: $scope.estabelecimento.Descricao
        };
        $scope.divEstabelecimento = true;
        if ($scope.Action == "Atualizar") {
            var estabelecimentoData = estabelecimentoService.Alterar(estabelecimento);
            estabelecimentoData.then(function (data) {
                ListarTodos();
                $scope.divEstabelecimento = false;
                if (data.status == 200) {
                    toastr["success"]("Estabelecimento Alterado com Sucesso!", "WebApiAngularJS");
                }
            }, function () {
                toastr["error"]("Erro ao Alterar Estabelecimento!", "WebApiAngularJS");
            });
        } else {
            var estabelecimentoData = estabelecimentoService.Incluir(estabelecimento);
            estabelecimentoData.then(function (data) {
                ListarTodos();
                $scope.divEstabelecimento = false;
                if (data.status == 200) {
                    toastr["success"]("Estabelecimento Cadastrado com Sucesso!", "WebApiAngularJS");
                }
            }, function () {
                toastr["error"]("Erro ao Cadastrar Estabelecimento!", "WebApiAngularJS");
            });
        }

    }
    $scope.RetornarPorId = function (estabelecimento) {
        var estabelecimentoData = estabelecimentoService.RetornarPorId(estabelecimento.Id);
        estabelecimentoData.then(function (_estabelecimento) {
            $scope.estabelecimento = _estabelecimento.data;
            $scope.Id = _estabelecimento.Id;
            $scope.Nome = _estabelecimento.Nome;
            $scope.Descricao = _estabelecimento.Descricao;
            $scope.Action = "Atualizar";
            $scope.divEstabelecimento = true;
        }, function () {
            toastr["error"]("Erro ao recuperar Estabelecimento!", "WebApiAngularJS");
        });
    }
    $scope.Excluir = function (estabelecimento) {
        var estabelecimentoData = estabelecimentoService.Excluir(estabelecimento.Id);
        estabelecimentoData.then(function (data) {
            if (data.status = 200) {
                toastr["success"]("Estabelecimento Excluído com Sucesso!", "WebApiAngularJS");
            }
            ListarTodos();
        }, function () {
            toastr["error"]("Erro ao Excluir Estabelecimento!", "WebApiAngularJS");
        });
    }
    $scope.Cancelar = function () {
        $scope.divEstabelecimento = false;
    }
    $scope.Novo = function () {
        LimpaCampos();
        $scope.Action = "Cadastrar Novo";
        $scope.divEstabelecimento = true;
    }
    function LimpaCampos() {
        $scope.Id = "";
        $scope.Nome = "";
        $scope.Descricao = "";
    }
    function ListarTodos() {

        var estabelecimentosData = estabelecimentoService.ListarTodos();

        estabelecimentosData.then(function (estabelecimento) {
            $scope.estabelecimentos = estabelecimento.data;

        }, function () {
            toastr["error"]("Erro ao obter Estabelecimentos!", "WebApiAngularJS");
        });

    }
});