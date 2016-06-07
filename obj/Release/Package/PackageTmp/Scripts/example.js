angular.module('plunker', ['ui.bootstrap', 'ngMap']);

var ModalDemoCtrl = function ($scope, $modal, $log) {



  $scope.lat = 34.834442;

  $scope.lng = -82.3686479;



  $scope.open = function (size) {



    var modalInstance = $modal.open({

      templateUrl: 'myModalContent.html',

      controller: ModalInstanceCtrl,

      size: size,

      resolve: {

        lat: function () {

          return $scope.lat;

        },

        lng: function () {

          return $scope.lng;

        }

      }

    });



    modalInstance.result.then(function (selectedItem) {

    }, function () {

      $log.info('Modal dismissed at: ' + new Date());

    });

  };

};



// Please note that $modalInstance represents a modal window (instance) dependency.

// It is not the same as the $modal service used above.



var ModalInstanceCtrl = function ($scope, $modalInstance, lat, lng) {



  $scope.lat = lat;

  $scope.lng = lng;



  $scope.ok = function () {

    $modalInstance.close();

  };



  $scope.cancel = function () {

    $modalInstance.dismiss('cancel');

  };

};

