'use strict';

module.exports = {

	listing: (function () {
		//Your Test Data
		var pageKey = 
		var page = 

		//Perform your Get
		$.get('@Url.Action("Donators","ListingController")', { pageKey:  , page: }, function (data) {
			//Populate your "rData" element with the results
			$("#listing").html(data);
		});
	})
};