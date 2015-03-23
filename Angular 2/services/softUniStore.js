export class SoftUniStore {
	constructor() {
		this.list = [];
		this._id = 0;
	}

	nextId() {
		this._id = this._id + 1;
		return this._id;
	}

	addDude(dude) {
		dude._id = this.nextId();
		this.list.push(dude);
	}

	removeDude(dude) {
		var index = this.list.indexOf(dude);
		this.list.splice(index, 1);
	}
}