import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import { LibeyUser } from 'src/app/entities/libeyuser';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-userinspect',
  templateUrl: './userinspect.component.html',
  styleUrls: ['./userinspect.component.css']
})
export class UserinspectComponent implements OnInit {

  inspectionList: LibeyUser[] = [];
  inspectionTypesList$!: Observable<any[]>;
  inspectionTypesList: any = [];
  libeyUserForm!: FormGroup;
  inspectionTypesMap: Map<number, string> = new Map()
  selectedUser: any;
  modalTitle: string = '';
  activateAddEditInspectionComponent: boolean = false;
  inspection: any;

  constructor(private service: LibeyUserService, private router: Router, private location: Location) { }

  openUpdate(documentNumber: string): void {
    this.router.navigate(['user/maintenance'], { queryParams: { documentNumber: documentNumber } });
  }

  saveUser(): void {
    const userData = this.libeyUserForm.value;
    this.service.Update(this.selectedUser, userData).subscribe(() => {
      this.router.navigate(['/ruta-a-la-lista']);
    });
  }

  ngOnInit(): void {
    this.chargeList();
    this.refreshInspectionTypesMap();
  }

  chargeList(): void {
    this.service.FindAll().subscribe(
      (response: any) => {
        this.inspectionList = response.datos;
      },
      (error) => {
        Swal.fire('Error', 'No se pudieron cargar las regiones.', 'error');
      }
    );
  }

  confirmDelete(item: any) {
    Swal.fire({
      title: '¿Estás seguro?',
      text: 'No podrás revertir esta acción!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sí, eliminar!',
      cancelButtonText: 'Cancelar'
    }).then((result) => {
      if (result.isConfirmed) {
        this.delete(item);
      }
    });
  }

  delete(item: any) {
    this.service.Delete(item).subscribe(response => {
      Swal.fire('Eliminado!', 'El registro ha sido eliminado.', 'success').then(() => {
        window.location.reload();
      });

    }, error => {
      Swal.fire('Error', 'Hubo un problema al eliminar el registro.', 'error');
    });
  }

  refreshInspectionTypesMap() {
    this.service.FindAll().subscribe(data => {
      this.inspectionTypesList = data;

      for (let i = 0; i < data.length; i++) {
        this.inspectionTypesMap.set(this.inspectionTypesList[i].id, this.inspectionTypesList[i].inspectionName);
      }
    })
  }

  return(): void {
    this.location.back();
  }
}
