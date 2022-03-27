


var app = angular.module("myApp", []);
app.controller("CountryController", function ($scope, $http, $rootScope, $filter) {

    $scope.addCountryToTable = function () {

        var PlayerInfoesArray = [];
        //var fdata = new FormData();  
        //fdata.Country_Name = $scope.Country_Name;
        var PlayerInfoes = [];
        PlayerInfoesArray.push({
            PlayerName: $scope.PlayerName,
            PlayerDistrict: $scope.PlayerDistrict
        });

        var data = {

            Country_Name: $scope.Country_Name
           /* PlayerInfoes: PlayerInfoesArray   */
        }
        

             


        //console.log(fdata);

         $http.post('/Countries/Create', JSON.stringify(data)).then(

            function (res) {

                $scope.message = res.data;
                $scope.Companydata();

            }
            , function (err) {

                $scope.message = err;

            }
        );

    }

    $scope.Companydata = function () {
        console.log('companyNalekekke');
        $http.get('/Countries/getAllData').then(

            function (res) {

                $rootScope.Companydataholder = res.data;
                console.log($scope.Companydataholder);

            }
            , function (err) {

                console.log(err);

            }
        );
    }
    $scope.Companydata();

    $scope.edit = function (Id, Country_Name) {

    }

    $scope.delete = function (Id, Country_Name) {

    }


});
app.controller("playerController", function ($scope, $http, $rootScope, $filter) {

    $scope.title = 'This is my first programe';
    $scope.IdDisable = true;
    $scope.Id = 0;
    $scope.IsComeFromVillage = true;
    $scope.JoiningDate = new Date();

    $scope.tabledata = function () {

        $http.get('/PlayerInfoes/getAllData').then(

            function (res) {

                $scope.tabledataholder = res.data;
                console.log($scope.tabledataholder);
                    
            }
            , function (err) {

                console.log(err);
                
            }
        );
    }

    $scope.tabledata();

    console.log('companyNalekekke');

    $scope.Companydata = function () {
       
        $http.get('/Countries/getAllData').then(

            function (res) {

                $rootScope.Companydataholder = res.data;
                console.log($scope.Companydataholder);

            }
            , function (err) {

                console.log(err);

            }
        );
    }
    $scope.Companydata();


    // data display that is stored into table
   
    $scope.edit = function (Id, PlayerName, PlayerDistrict, IsComeFromVillage, JoiningDate, CountId ) {

        
        document.getElementById("CountryDdl").value = CountId;
       
        $scope.Id = Id;
        $scope.PlayerName = PlayerName;
        $scope.PlayerDistrict = PlayerDistrict;
        $scope.IsComeFromVillage = IsComeFromVillage;
        var tempDate = JoiningDate.slice(6, -2);
        $scope.JoiningDate = new Date(Number(tempDate));
      
        $scope.$apply(function () {
            $scope.CountId = CountId;
        });
        console.log($scope.JoiningDate);
       

    }

    $scope.delete = function (Id, PlayerName, PlayerDistrict, IsComeFromVillage, JoiningDate, CountId) {
        document.getElementById("CountryDdl").value = CountId;
        $scope.IdDisable = true;
        $scope.Id = Id;
        $scope.PlayerName = PlayerName;
        $scope.PlayerDistrict = PlayerDistrict;
        $scope.IsComeFromVillage = IsComeFromVillage;
        var tempDate = JoiningDate.slice(6, -2);
        $scope.JoiningDate = new Date(Number(tempDate));
        $scope.CountId = CountId;
        document.getElementById("CountryDdl").value = CountId;




    }


    $scope.addToTable = function (Id, PlayerName, PlayerDistrict, IsComeFromVillage, JoiningDate, CountId) {
       

        var fdata = new FormData();

        fdata.Id = $scope.Id;
        fdata.PlayerName = $scope.PlayerName;
        fdata.PlayerDistrict = $scope.PlayerDistrict;
        fdata.image = $scope.Image;
        fdata.CountId = $scope.CountId;

        fdata.IsComeFromVillage = $scope.IsComeFromVillage;
        fdata.JoiningDate = $scope.JoiningDate;
        fdata.image_Path = $scope.imagePath;
        console.log(fdata);

        $http.post('/PlayerInfoes/Create', JSON.stringify( fdata)).then(

            function (res) {

                $scope.message = res.data;
                console.log($scope.message);
                $scope.tabledata();
                $scope.Id = 0;
                $scope.PlayerName = '';
                $scope.PlayerDistrict = '';

            }
            , function (err) {

                $scope.message = err;

            }
        );

    }


    $scope.editToTable = function (Id, PlayerName, PlayerDistrict, IsComeFromVillage, JoiningDate, CountId) {

        var fdata = new FormData();

        fdata.Id = Id;
        fdata.PlayerName = PlayerName;
        fdata.PlayerDistrict = PlayerDistrict;
        fdata.image = $scope.Image;
        fdata.IsComeFromVillage = IsComeFromVillage;
        fdata.JoiningDate = JoiningDate;
        fdata.CountId = CountId;

        console.log(fdata);

        $http.post('/PlayerInfoes/Edit', JSON.stringify(fdata)).then(

            function (res) {

                $scope.message = res.data;
                console.log($scope.message);
                $scope.tabledata();
                $scope.Id = 0;
                $scope.PlayerName = '';
                $scope.PlayerDistrict = '';

            }
            , function (err) {

                $scope.message = err;

            }
        );

    }


    $scope.deleteToTable = function (Id, PlayerName, PlayerDistrict, IsComeFromVillage, JoiningDate, CountId) {

        var paramObject = { Id: Id, PlayerName: PlayerName, PlayerDistrict: PlayerDistrict, IsComeFromVillage: IsComeFromVillage, JoiningDate: JoiningDate};

        $http.post('/PlayerInfoes/Delete', paramObject).then(

            function (res) {

                $scope.message = res.data;
                console.log($scope.message);
                $scope.tabledata();
                $scope.Id = 0;
                $scope.PlayerName = '';
                $scope.PlayerDistrict = '';

            }
            , function (err) {

                $scope.message = err;

            }
        );

    }


    $scope.upload = function () {


        var filedata = new FormData();
        var config = {

            headers: {
                'Content-Type': undefined
            },
            transformResponse: angular.identity

        }

        filedata.append(document.getElementById("image").files[0].name, document.getElementById("image").files[0]);

        $scope.imagePath = '';
        $http.post('/PlayerInfoes/UploadImage', filedata, config).then(

            function (res) {
                $scope.imagePath = res.data;
            }
            , function (err) {
                console.log(err);
                $scope.imagePath = '';
            }
        );




        var file = document.getElementById("image").files[0];
        var base64;
        var f = new FileReader();
        f.onload = function (event) {

            base64 = event.target.result;
            $scope.$apply(function () {
                $scope.Image = base64;
            });
               
                console.log('$scope.Image');
                console.log($scope.Image);

        }
        f.readAsDataURL(file);

    }




});


