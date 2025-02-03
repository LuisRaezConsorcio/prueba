import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import swal from 'sweetalert2';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import { UbigeoService } from 'src/app/core/service/ubigeo/ubigeo.service';
import { Region } from 'src/app/entities/region';
import { Ubigeo } from 'src/app/entities/ubigeo';
import { Province } from 'src/app/entities/province';
import { DocumentType } from 'src/app/entities/documenttype';
import { DocumenttypeService } from 'src/app/core/service/documenttype/documenttype.service';
import { RegionService } from 'src/app/core/service/region/region.service';
import { ProvinceService } from 'src/app/core/service/province/province.service';
import { Location } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-usermaintenance',
  templateUrl: './usermaintenance.component.html',
  styleUrls: ['./usermaintenance.component.css']
})
export class UsermaintenanceComponent implements OnInit {

  libeyUserForm!: FormGroup;
  documentTypes: DocumentType[] = [];
  regions: Region[] = [];
  provinces: Province[] = [];
  ubigeos: Ubigeo[] = [];
  provinceDisabled = true;
  ubigeoDisabled = true;

  selectedRegionCode: string = '';
  selectedProvinceCode: string = '';
  selectedUbigeoCode: string = '';

  isEditMode: boolean = false;
  documentNumber: string | null = null;

  constructor(
    private fb: FormBuilder,
    private libeyUserService: LibeyUserService,
    private documentTypeService: DocumenttypeService,
    private ubigeoService: UbigeoService,
    private regionService: RegionService,
    private provinceService: ProvinceService,
    private router: Router,
    private route: ActivatedRoute,
    private location: Location
  ) {
    this.libeyUserForm = this.fb.group({
      documentNumber: ['', Validators.required],
      documentTypeId: [[], Validators.required],
      name: ['', Validators.required],
      fathersLastName: ['', Validators.required],
      mothersLastName: ['', Validators.required],
      address: ['', Validators.required],
      regionCode: [[], Validators.required],
      provinceCode: [{ value: [], disabled: true }, Validators.required],
      ubigeoCode: [{ value: [], disabled: true }, Validators.required],
      phone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]],
      active: [true]
    });
  }

  ngOnInit(): void {
    this.documentNumber = this.route.snapshot.queryParamMap.get('documentNumber')
    if (this.documentNumber) {
      this.isEditMode = true;
      this.loadUserData();
    }

    this.loadDocumentTypes();
    this.loadRegions();
  }

  loadUserData(): void {
    this.libeyUserService.Find(this.documentNumber!).subscribe(
      (response: any) => {
        if (response.datos) {
          this.libeyUserForm.patchValue(response.datos);

          this.libeyUserForm.get('provinceCode')?.enable();
          this.libeyUserForm.get('ubigeoCode')?.enable();

          const regionCode = response.datos.regionCode;
          const provinceCode = response.datos.provinceCode;
          const ubigeoCode = response.datos.ubigeoCode;

          this.selectedRegionCode = regionCode
          this.selectedProvinceCode = provinceCode
          this.selectedUbigeoCode = ubigeoCode

          this.loadRegions();
          this.loadProvince(regionCode);
          this.loadUbigeo(regionCode, provinceCode);
        }
      },
      (error) => {
        swal.fire('Error', 'No se pudo cargar la información del usuario.', 'error');
      }
    );
  }

  loadDocumentTypes(): void {
    this.documentTypeService.FindAll().subscribe(
      (response: any) => {
        this.documentTypes = response.datos;
      },
      (error) => {
        swal.fire('Error', 'No se pudieron cargar los tipos de documento.', 'error');
      }
    );
  }

  loadRegions(): void {
    this.regionService.FindAll().subscribe(
      (response: any) => {
        this.regions = response.datos;
      },
      (error) => {
        swal.fire('Error', 'No se pudieron cargar las regiones.', 'error');
      }
    );
  }

  loadProvince(region: string): void {
    this.provinceService.GetByRegion(region).subscribe(
      (response: any) => {
        this.provinces = response.datos;
      },
      (error) => {
        swal.fire('Error', 'No se pudieron cargar las provincias.', 'error');
      }
    );
  }

  loadUbigeo(region: string, province: string): void {
    this.ubigeoService.GetByRegionAndProvince(region, province).subscribe(
      (response: any) => {
        this.ubigeos = response.datos;
      },
      (error) => {
        swal.fire('Error', 'No se pudieron cargar los Ubigeos.', 'error');
      }
    );
  }

  onRegionChange(selectedRegion: any): void {
    const regionCode = selectedRegion.regionCode

    this.provinceService.GetByRegion(regionCode).subscribe(
      (response: any) => {
        this.provinces = response.datos;
        this.libeyUserForm.controls['provinceCode'].setValue([]);
        this.libeyUserForm.controls['ubigeoCode'].setValue([]);
        this.libeyUserForm.get('provinceCode')?.enable();
        this.libeyUserForm.get('ubigeoCode')?.disable();
        this.selectedRegionCode = regionCode
      },
      (error) => {
        swal.fire('Error', 'No se pudieron cargar las provincias.', 'error');
      }
    );
  }

  onProvinceChange(selectedProvince: any): void {
    const regionCode = selectedProvince.regionCode
    const provinceCode = selectedProvince.provinceCode
    this.ubigeos = []
    this.ubigeoService.GetByRegionAndProvince(regionCode, provinceCode).subscribe(
      (response: any) => {
        this.ubigeos = response.datos;
        this.libeyUserForm.controls['ubigeoCode'].setValue([]);
        this.libeyUserForm.get('ubigeoCode')?.enable();
        this.selectedProvinceCode = provinceCode
      },
      (error) => {
        swal.fire('Error', 'No se pudieron cargar los ubigeos.', 'error');
      }
    );
  }

  submit(): void {
    if (this.libeyUserForm.valid) {
      if (this.isEditMode) {
        const userData = this.libeyUserForm.value;
        this.libeyUserService.Update(userData.documentNumber, userData).subscribe(
          response => {
            this.Clear();
            swal.fire('Success', 'Usuario Actualizado Exitosamente', 'success').then(() => {
              this.return();
            });
          },
          error => {
            swal.fire('Oops!', 'Error al actualizar el usuario', 'error');
          }
        );
      } else {
        const userData = this.libeyUserForm.value;
        this.libeyUserService.Create(userData).subscribe(
          response => {
            this.Clear();
            swal.fire('Success', 'Usuario Creado Exitosamente', 'success').then(() => {
              this.return();
            });
          },
          error => {
            swal.fire('Oops!', 'Error al crear usuario', 'error');
          }
        );
      }
    } else {
      swal.fire('Oops!', 'Por favor, complete todos los campos obligatorios.', 'error');
    }
  }

  Clear(): void {
    this.libeyUserForm.reset();

    this.provinces = [];
    this.ubigeos = [];

    this.libeyUserForm.controls['provinceCode'].disable();
    this.libeyUserForm.controls['ubigeoCode'].disable();

    this.provinceDisabled = true;
    this.ubigeoDisabled = true;
  }

  return(): void {
    this.location.back();
  }
}

