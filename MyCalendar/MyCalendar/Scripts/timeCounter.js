var countDown = function(theSelector, time){
	var output = "";
	var dTime = Date.parse(time);
  var theDate = Date.parse(new Date());
  var difference = dTime - theDate;
  var milliseconds = difference % 1000;
  
  function addZero(number){
  	if(number <= 9){
    	number = "0" + number;
    }
    return number;
  }
  
  x = difference / 1000;
  seconds = addZero(parseInt(x % 60));
  x /= 60;
  minutes = addZero(parseInt(x % 60));
  x /= 60;
  hours = addZero(parseInt(x % 24));
  x /= 24;
  days = addZero(parseInt(x));
  
  output += "<span class='days bg-warning text-light'>" + days + "<small>روز</small></span>";
  output += "<span class='hours bg-warning text-light'>" + hours + "<small>ساعت</small></span>";
  output += "<span class='minutes bg-warning text-light'>" + minutes + "<small>دقیقه</small></span>";
  output += "<span class='seconds bg-warning text-light'>" + seconds + "<small>ثانیه</small></span>";
  document.querySelector(theSelector).innerHTML = output;
}