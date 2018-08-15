app.controller('TaskController', ['$scope', 'TaskResource',
    function ($scope, TaskResource) {

        var _save = function () {
            TaskResource.save($scope.currentTask,
                function (response) {
                    _init();
                },
                function (error) {
                    alert(error);
                }
            );
        }

        var _update = function () {
            TaskResource.update($scope.currentTask,
                function (response) {
                    _init();
                },
                function (error) {
                    alert(error);
                }
            );
        }

        var _createMode = function () {
            $scope.currentMode = {};
            $scope.currentMode.Title = "Adicionar tarefa";
            $scope.save = _save;
        }

        var _editMode = function () {
            $scope.currentMode = {};
            $scope.currentMode.Title = "Editar tarefa";
            $scope.currentMode.exibirExcluir = true;
            $scope.save = _update;
        }

        var _getTasks = function () {

            TaskResource.getOpen(
                function (response) {
                    $scope.openTasks = response;
                },
                function (error) {
                    alert(error);
                }
            );

            TaskResource.getResolved(
                function (response) {
                    $scope.resolvedTasks = response;
                },
                function (error) {
                    alert(error);
                }
            );
        }

        var _init = function () {
            _getTasks();
            $scope.currentMode = null;
            $scope.save = _save;
        };

        $scope.editTask = function (task) {
            $scope.currentTask = task;
            _editMode();
        }

        $scope.cancel = function () {
            $scope.currentMode = null;
        }

        $scope.createTask = function () {
            _createMode();
        }

        $scope.delete = function () {
            if (confirm('Deseja realmente excluir este registro?')) {
                TaskResource.delete($scope.currentTask,
                    function (response) {
                        _init();
                    },
                    function (error) {
                        alert(error);
                    }
                );
            }
        }


        _init();
    }]);