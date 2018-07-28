/*--- toggle菜单 ---*/
		$(function() {
		    $('.toggle-nav').click(function() {
		        toggleNavigation();
		    });
		    $('#toggle-right').click(function () {
		    	toggleRightbar();
		    });
		});
// 左栏		  
		function toggleNavigation() {
		    if ($('#container').hasClass('display-nav')) {
		        // Close Nav
		        $('#container').removeClass('display-nav');
		    } else {
		        // Open Nav
		        $('#container').addClass('display-nav');
		    }
		}
// 右栏
		function toggleRightbar() {
		    if ($('#container').hasClass('display-right')) {
		        // Close Nav
		        $('#container').removeClass('display-right');
		    } else {
		        // Open Nav
		        $('#container').addClass('display-right');
		    }
		}

			