// DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
//
// @Authors:
//       Timotheus Pokorra <tp@tbits.net>
//
// Copyright 2017-2018 by TBits.net
//
// This file is part of OpenPetra.
//
// OpenPetra is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// OpenPetra is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with OpenPetra.  If not, see <http://www.gnu.org/licenses/>.
//

var last_opened_entry_data = {};

$('document').ready(function () {
	var r = {};
	api.post('serverMPartner.asmx/TPartnerSetupWebConnector_LoadPartnerTypes', {}).then(function (data) {
		parsed = JSON.parse(data.data.d);
		display_report_form(parsed);
	})
});

function display_report_form(parsed) {
	// generated fields
	load_tags(parsed.result.PType, $('#reportfilter'));
}

function calculate_report() {
	let obj = $('#reportfilter');
	// extract information from a jquery object
	let params = extract_data(obj);

	// get all tags for the partner
	applied_tags = []
	obj.find('#types').find('.tpl_check').each(function (i, o) {
		o = $(o);
		if (o.find('input').is(':checked')) {
			applied_tags.push(o.find('data').attr('value'));
		}
	});

	params['param_explicit_specialtypes'] = applied_tags;
	params['xmlfiles'] = 'Partner/partnerbyspecialtype.xml';
	params['currentReport'] = 'Partner By Special Type';

	// now make the parameters into a data table
	// TODO: make this a generic function
	param_table = []
	for (var param in params) {
		param_table.push({'name': param, 'value': 'string:' + params[param], 'column': -1, 'level': -1, 'subreport': -1});
	}

	// send request
	let r = {}
	api.post('serverMReporting.asmx/Create_TReportGeneratorUIConnector', r).then(function (data) {
		let UIConnectorUID = data.data.d;

		let r = {'UIConnectorObjectID': UIConnectorUID,
			'AParameters': JSON.stringify(param_table)
		};

		api.post('serverMReporting.asmx/TReportGeneratorUIConnector_Start', r).then(function (data) {
			// TODO: use TReportGeneratorUIConnector_GetProgress and sleep to check if report was finished
			setTimeout(function() {
				let r = {'UIConnectorObjectID': UIConnectorUID, 'AWrapColumn': 'true'};
				api.post('serverMReporting.asmx/TReportGeneratorUIConnector_DownloadText', r).then(function (data) {
					report = data.data.d;
					$('#reporttxt').html("<pre>"+report+"</pre>");
				});
				}, 3000);
		});
	});

}

// used to load all available tags
function load_tags(all_tags, obj) {
	let p = $('<div class="container">');
	for (tag of all_tags) {
		let pe = $('[phantom] .tpl_check').clone();
		pe.find('data').attr('value', tag['p_type_code_c']);
		pe.find('span').text(tag['p_type_description_c']);
		p.append(pe);
	}
	obj.find('#types').html(p);
	return obj;
}
