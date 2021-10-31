/*
  This file is automatically generated. Any changes will be overwritten.
  Modify benutzer-neu.component.ts instead.
*/
import { LOCALE_ID, ChangeDetectorRef, ViewChild, AfterViewInit, Injector, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Subscription } from 'rxjs';

import { DialogService, DIALOG_PARAMETERS, DialogRef } from '@radzen/angular/dist/dialog';
import { NotificationService } from '@radzen/angular/dist/notification';
import { ContentComponent } from '@radzen/angular/dist/content';
import { TemplateFormComponent } from '@radzen/angular/dist/template-form';
import { LabelComponent } from '@radzen/angular/dist/label';
import { RequiredValidatorComponent } from '@radzen/angular/dist/required-validator';
import { DropDownComponent } from '@radzen/angular/dist/dropdown';
import { TextBoxComponent } from '@radzen/angular/dist/textbox';
import { ListBoxComponent } from '@radzen/angular/dist/listbox';
import { PasswordComponent } from '@radzen/angular/dist/password';
import { TextAreaComponent } from '@radzen/angular/dist/textarea';
import { ButtonComponent } from '@radzen/angular/dist/button';

import { ConfigService } from '../config.service';

import { DbOptimoService } from '../db-optimo.service';
import { SecurityService } from '../security.service';

export class BenutzerNeuGenerated implements AfterViewInit, OnInit, OnDestroy {
  // Components
  @ViewChild('content1') content1: ContentComponent;
  @ViewChild('form0') form0: TemplateFormComponent;
  @ViewChild('label1') label1: LabelComponent;
  @ViewChild('requiredValidator1') requiredValidator1: RequiredValidatorComponent;
  @ViewChild('baseId') baseId: DropDownComponent;
  @ViewChild('label2') label2: LabelComponent;
  @ViewChild('requiredValidator4') requiredValidator4: RequiredValidatorComponent;
  @ViewChild('anmeldename') anmeldename: TextBoxComponent;
  @ViewChild('label3') label3: LabelComponent;
  @ViewChild('requiredValidator2') requiredValidator2: RequiredValidatorComponent;
  @ViewChild('initialen') initialen: TextBoxComponent;
  @ViewChild('roleNamesLabel') roleNamesLabel: LabelComponent;
  @ViewChild('requiredValidator3') requiredValidator3: RequiredValidatorComponent;
  @ViewChild('roleNames') roleNames: ListBoxComponent;
  @ViewChild('passwordLabel') passwordLabel: LabelComponent;
  @ViewChild('passwordRequiredValidator') passwordRequiredValidator: RequiredValidatorComponent;
  @ViewChild('password') password: PasswordComponent;
  @ViewChild('confirmPasswordLabel') confirmPasswordLabel: LabelComponent;
  @ViewChild('confirmPasswordRequiredValidator') confirmPasswordRequiredValidator: RequiredValidatorComponent;
  @ViewChild('confirmPassword') confirmPassword: PasswordComponent;
  @ViewChild('label19') label19: LabelComponent;
  @ViewChild('notiz') notiz: TextAreaComponent;
  @ViewChild('button0') button0: ButtonComponent;
  @ViewChild('button1') button1: ButtonComponent;
  @ViewChild('textarea0') textarea0: TextAreaComponent;

  router: Router;

  cd: ChangeDetectorRef;

  route: ActivatedRoute;

  notificationService: NotificationService;

  configService: ConfigService;

  dialogService: DialogService;

  dialogRef: DialogRef;

  httpClient: HttpClient;

  locale: string;

  _location: Location;

  _subscription: Subscription;

  dbOptimo: DbOptimoService;

  security: SecurityService;
  rstRollen: any;
  rstBase: any;
  dsoBenutzer: any;
  dsoUser: any;
  parameters: any;

  constructor(private injector: Injector) {
  }

  ngOnInit() {
    this.notificationService = this.injector.get(NotificationService);

    this.configService = this.injector.get(ConfigService);

    this.dialogService = this.injector.get(DialogService);

    this.dialogRef = this.injector.get(DialogRef, null);

    this.locale = this.injector.get(LOCALE_ID);

    this.router = this.injector.get(Router);

    this.cd = this.injector.get(ChangeDetectorRef);

    this._location = this.injector.get(Location);

    this.route = this.injector.get(ActivatedRoute);

    this.httpClient = this.injector.get(HttpClient);

    this.dbOptimo = this.injector.get(DbOptimoService);
    this.security = this.injector.get(SecurityService);
  }

  ngAfterViewInit() {
    this._subscription = this.route.params.subscribe(parameters => {
      if (this.dialogRef) {
        this.parameters = this.injector.get(DIALOG_PARAMETERS);
      } else {
        this.parameters = parameters;
      }
      this.load();
      this.cd.detectChanges();
    });
  }

  ngOnDestroy() {
    if (this._subscription) {
      this._subscription.unsubscribe();
    }
  }


  load() {
    this.dbOptimo.getVwRollens(null, null, null, null, null, null, null, null)
    .subscribe((result: any) => {
      this.rstRollen = result.value;
    }, (result: any) => {

    });

    this.dbOptimo.getVwBaseAlles(null, null, null, null, null, null, null, null)
    .subscribe((result: any) => {
      this.rstBase = result.value;
    }, (result: any) => {

    });

    this.dsoBenutzer = {
    "BaseID": 0,
    "AspNetUsers_Id": "",
    "Benutzername": "",
    "Initialen": "",
    "Notiz": ""
};

    this.dsoUser = {
    "EMail": "",
    "Password": "",
    "ConfirmPassword": "",
    "RoleNames": []
};
  }

  form0Submit(event: any) {
    this.dsoUser.EMail = event.BaseID
this.dsoUser.Password = event.Password
this.dsoUser.ConfirmPassword = event.ConfirmPassword
this.dsoUser.RoleNames = event.RoleNames

    this.security.createUser(this.dsoUser)
    .subscribe((result: any) => {
      this.dsoBenutzer.BaseID = event.BaseID
this.dsoBenutzer.AspNetUsers_Id = result.Id
this.dsoBenutzer.Benutzername = event.Anmeldename
this.dsoBenutzer.Initialen = event.Initialen
this.dsoBenutzer.Notiz = event.Notiz

      this.dbOptimo.createBenutzer(null, this.dsoBenutzer)
      .subscribe((result: any) => {
        this.notificationService.notify({ severity: "success", summary: ``, detail: `Benutzer erstellt` });

        this.dialogRef.close(result);
      }, (result: any) => {
        this.notificationService.notify({ severity: "error", summary: ``, detail: `Benutzer (Schritt 2) konnte nicht erstellt werden!` })
        .subscribe(() => {

        });
      });
    }, (result: any) => {
      this.notificationService.notify({ severity: "error", summary: ``, detail: `Benutzer (Schritt 1) konnte nicht erstellt werden!` });
    });
  }

  BaseIDChange(event: any) {
    this.anmeldename.value = event.Name2 + ' ' + event.Name1;
this.initialen.value = event.Name2.substr(0,1) + event.Name1.substr(0,1);

this.password.value = event.Name2 + '123#';
this.confirmPassword.value = this.password.value;
this.roleNames.value = ["Kundenbetreuung"];
  }

  button1Click(event: any) {
    if (this.dialogRef) {
      this.dialogRef.close();
    } else {
      this._location.back();
    }
  }
}
