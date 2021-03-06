var MainController = ['$scope', '$http', function ($scope, $http) {

    $scope.sendForm = function () {
        console.log($scope.model.search);
        $http({
            method: 'GET',
            url: '/api/search?txt_search=' + $scope.model.search
        })
        .then(function () {
            console.log('sucesso a executar o post');
        }, function () {
            console.log('Erro ao executar o post');
      });
    };


            $http.get('/api/equipment')
                .then(function (response) {
                    $scope.equipments = response.data;
                    console.log($scope.equipments);
                }, function () {
                    console.log('Error');
                });

            $http.get('/api/material')
                .then(function (response) {
                    $scope.materials = response.data;
                    console.log($scope.materials);
                }, function () {
                    console.log('Error');
                });

            $http.get('/api/purchase_order')
                .then(function (response) {
                    $scope.purchase_orders = response.data;
                    console.log($scope.purchase_order);
                }, function () {
                    console.log('Error');
                });

            $http.get('/api/sales_order')
                .then(function (response) {
                    $scope.sales_orders = response.data;
                    console.log($scope.sales_order);
                }, function () {
                    console.log('Error');
                });

            $http.get('/api/workforce')
                .then(function (response) {
                    $scope.workforce = response.data;
                    console.log($scope.workforce);
                }, function () {
                    console.log('Error');
                });
        }];
