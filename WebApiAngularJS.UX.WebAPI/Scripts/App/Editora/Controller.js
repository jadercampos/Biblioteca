app.controller("editoraCtrl", function ($scope, editoraService) {

    $scope.divEditora = false;

    ListarTodos();
    $scope.Salvar = function () {
        debugger;
        var editora = {
            Id: $scope.editora.Id,
            Nome: $scope.editora.Nome,
            DtInc: $scope.editora.DtInc,
            DtAlt: $scope.editora.DtAlt
        };
        $scope.divEditora = true;
        if ($scope.Action == "Atualizar") {
            var editoraData = editoraService.Alterar(editora);
            editoraData.then(function (data) {
                ListarTodos();
                $scope.divEditora = false;
                if (data.status == 200) {
                    toastr["success"]("Editora Alterada com Sucesso!", "WebApiAngularJS");
                }
            }, function () {
                toastr["error"]("Erro ao Alterar Editora!", "WebApiAngularJS");
            });
        } else {
            var editoraData = editoraService.Incluir(editora);
            editoraData.then(function (data) {
                ListarTodos();
                $scope.divEditora = false;
                if (data.status == 200) {
                    toastr["success"]("Editora Cadastrada com Sucesso!", "WebApiAngularJS");
                }
            }, function () {
                toastr["error"]("Erro ao Cadastrar Editora!", "WebApiAngularJS");
            });
        }

    }
    $scope.RetornarPorId = function (editora) {
        var editoraData = editoraService.RetornarPorId(editora.Id);
        editoraData.then(function (_editora) {
            $scope.editora = _editora.data;
            $scope.Id = _editora.Id;
            $scope.Nome = _editora.Nome;
            $scope.DtInc = _editora.DtInc;
            $scope.DtAlt = _editora.DtAlt;
            $scope.Action = "Atualizar";
            $scope.divEditora = true;
        }, function () {
            toastr["error"]("Erro ao recuperar Editora!", "WebApiAngularJS");
        });
    }
    $scope.Excluir = function (editora) {
        var editoraData = editoraService.Excluir(editora.Id);
        editoraData.then(function (data) {
            if (data.status = 200) {
                toastr["success"]("Editora Excluída com Sucesso!", "WebApiAngularJS");
            }
            ListarTodos();
        }, function () {
            toastr["error"]("Erro ao Excluir Editora!", "WebApiAngularJS");
        });
    }
    $scope.Cancelar = function () {
        $scope.divEditora = false;
    }
    $scope.Novo = function () {
        LimpaCampos();
        $scope.Action = "Cadastrar Nova";
        $scope.divEditora = true;
    }
    function LimpaCampos() {
        if ($scope.editora) {
            $scope.editora.Id = "";
            $scope.editora.Nome = "";
            $scope.editora.DtInc = "";
            $scope.editora.DtAlt = "";
        }
    }
    function ListarTodos() {

        var editorasData = editoraService.ListarTodos();

        editorasData.then(function (editora) {
            $scope.editoras = editora.data;

        }, function () {
            toastr["error"]("Erro ao obter Editoras!", "WebApiAngularJS");
        });

    }
});