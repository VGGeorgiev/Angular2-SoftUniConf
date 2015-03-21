app.factory('SoftUniStore', function () {
	var list = [];
	var id = 0;

	function nextId() {
		id = id + 1;
		return id;
	}

	function addDude(dude) {
		dude._id = nextId();
		list.push(dude);
	}

	function removeDude(dude) {
		var index = list.indexOf(dude);
		list.splice(index, 1)[0];
	}

	return {
		addDude: addDude,
		removeDude: removeDude,
		list: list
	}
});