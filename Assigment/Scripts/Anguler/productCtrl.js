app.controller("productCtrl", [
    '$scope',
    'productSrv',
    '$window' ,
    function ($scope, productSrv,$window) {

        $scope.pagination = {
            currentPage: 1,
            totalItems: 0,
            entryLimit: 15,
            noOfPages : 0
        };
        $scope.search = "";

        $scope.Start = function () {

            $scope.getProductData();

        }
      
        $scope.getProductData = function() {
            var servCall = productSrv.getProductsData($scope.search, $scope.pagination.currentPage);
            servCall.then(function (d) {
                debugger
                $scope.ProductsList = d.data.Data.Products;
                $scope.pagination.noOfPages = d.data.Data.totalPages;
                $scope.pagination.totalItems = d.data.Data.total;

            }, function (error) {
                 //   $log.error('Oops! Something went wrong while fetching the data.')
                })
        }   

        $scope.pageChanged = function (page) {
            debugger

            $scope.pagination.currentPage = page;
            $scope.getProductData();
        };


       
    
        $scope.Start();
    }]
);
