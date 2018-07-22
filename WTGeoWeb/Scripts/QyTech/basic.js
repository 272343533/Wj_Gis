
	$('#btnlogin').click(function(){
		//alert("hhahhha");
		var name = $("#username").val();
		var psw = $("#password").val();

		$.ajax({
			type:"GET",
			url:"http://122.114.38.213:8080/td_gis/home/login?username="+name+"&password="+psw,
			dataType:"JSON",
			// data:{username:name,psw:psw},
			success:function(data){
				if (data=="管理员") {
					window.location.href="http://www.baidu.com"
				}else{
					alert("error")
				}
			
				}


		})
	})

