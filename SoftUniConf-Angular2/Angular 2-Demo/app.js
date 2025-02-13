import { Component, Template, bootstrap, Foreach } from 'angular2/angular2';
import { SoftUniStore } from 'services/softUniStore';

@Component({
	selector: 'my-app',
	// componentServices: [
	//     bind(SoftUniStore).toClass(ConfSoftUniStore)
	// ]
	componentServices: [
		SoftUniStore
	]
})
@Template({ 
	url: 'templates/home', // inline: '<h1>Hello {{ name }}</h1>'
	directives: [Foreach] 
})
class SoftUniComponent {
	softUniStore: SoftUniStore;
	dudes: Array;

	constructor(store: SoftUniStore) {
		this.softUniStore = store;
		this.title = 'SoftUni Dudes';
		this.dudes = store.list;
	}

	addDude($event, newDude) {
		if($event.which === 13) {
			if (newDude.value) {
				this.softUniStore.addDude({
					name: newDude.value
				});

				newDude.value = '';
			}; 
		}
	}

	removeDude(dude) {
		this.softUniStore.removeDude(dude);
	}
}

bootstrap(SoftUniComponent);