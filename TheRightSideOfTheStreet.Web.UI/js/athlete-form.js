'use strict';

module.exports = {

	formInit: function () {
		const $form = $("#show-yourself-form");
		if ($form.length === 0) return;

		$form.data('validator').settings.ignore = "";
	},

	handleFormSubmit: function () {
		$('#showYourselfFormButton').on('click', function (e) {
			e.preventDefault();
			const $form = $(this).closest('form');
			const $achievements = $form.find('[achievements]');
			const $inputs = $achievements.children('input:text');
			const $achievementsHidden = $achievements.next();

			$achievementsHidden.val('');

			for (let i = 0; i < $inputs.length; i++) {
				const $item = $inputs[i];
				if ($item.value.trim().length === 0) continue;
				const oldValue = $achievementsHidden.val();
				$achievementsHidden.val(oldValue + $item.value + '|');
			}

			if (!$form.valid()) return;
			$form.submit();
		});
	},

	showImagePreview: function () {

		$("#addImage").change(function () {

			const File = this.files;

			if (File && File[0]) {
				readImage(File[0]);
			}

		})

		const readImage = function (file) {

			const reader = new FileReader;
			const image = new Image;

			if (file) {
				reader.readAsDataURL(file);
			}
			reader.onload = function (_file) {

				image.src = _file.target.result;
				image.onload = function () {

					$("#targetImg").attr('src', _file.target.result);
					$('#icon').hide();
					$('#text').hide();

				}

			}

		}
	},

	showAchievementsInput: function () {

		$("[add-achievement-btn]").on('click', function () {
			const $this = $(this);
			const $parent = $this.parent();

			$parent.append("<input type='text' value=''>");
		})
	},

	hideCountryAndCityInput: function () {
		$('#Crew').on('change', function () {

			const crew = $("#Crew option:selected").text();

			$("#Country").val(crew);
			$("#Country").hide();

			$("#City").val(crew);
			$("#City").hide();

			if ($("#Crew option:selected").val() === "") {
				$("#Country").val('').show();

				$("#City").val('').show();
			}
		});
	},

	previewImages: function () {

			const originalImgSrc = $('.show-yourself-content-second img:eq(5)').attr('src');
			const preview = document.querySelector('.show-yourself-content-second');
			let i = 0;


		if (this.files) {

			$('div.show-yourself-content-second img').attr("src", originalImgSrc);

			[].forEach.call(this.files, function (file) {

				var reader = new FileReader();
				reader.addEventListener("load", function () {
					const $image = preview.querySelectorAll('img')
					$image[i].src = this.result;
					$image[i].width = 197;
					i++;
				}, false);

				reader.readAsDataURL(file);

			});
		}	
	},

	athleteRegOnly: function () {

		if ($('body').hasClass('athlete-form-page')) {
			
			document.querySelector('#file-input').addEventListener("change", this.previewImages, false);
		}
	}
	
};