import { Component, OnInit, TemplateRef } from '@angular/core';
import { AbstractControl, Form, FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';
import { ActivatedRoute } from '@angular/router';
import { EventoService } from '@app/services/evento.service';
import { Evento } from '@app/models/Evento';
import { NgxSpinner, NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Lote } from '@app/models/Lote'
import { LoteService } from '@app/services/lote.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-evento-detalhe ',
  templateUrl: './evento-detalhe.component.html',
  styleUrls: ['./evento-detalhe.component.scss'],
})
export class EventoDetalheComponent implements OnInit {
  modalRef: BsModalRef;
  eventoId: number;
  form: FormGroup;
  ismeridian = false;
  mytime: Date = new Date();
  evento = {} as Evento;
  estadoSalvar = 'post';
  loteAtual = { id: 0, nome: '', indice: 0 };

  get modoEditar(): boolean {
    return this.estadoSalvar === 'put';
  }

  get lotes(): FormArray {
    return this.form.get('lotes') as FormArray;
  }

  get f(): any {
    return this.form.controls;
  }
  get bsConfig(): any {
    return {
      isAnimated: true,
      adaptivePosition: true,
      dateInputFormat: 'DD/MM/YYYY',
      containerClass: 'theme-default',
      showWeekNumbers: false,
    };
  }

  constructor(private fb: FormBuilder,
    private localeService: BsLocaleService,
    private router: ActivatedRoute,
    private eventoService: EventoService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private loteService: LoteService,
    private modalService: BsModalService
  ) {
    defineLocale('pt-br', ptBrLocale);
    localeService.use('pt-br');
  }


  ngOnInit(): void {
    this.validation();
    this.carregarEvento();
  }

  public removerLote(template: TemplateRef<any>, indice: number): void {
    this.loteAtual.id = this.lotes.get(indice + '.id').value;
    this.loteAtual.nome = this.lotes.get(indice + '.nome').value;
    this.loteAtual.indice = indice;


    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }
  confirmDeleteLote(): void {
    this.modalRef.hide();
    this.spinner.show();
    this.loteService.deleteLote(this.eventoId, this.loteAtual.id).subscribe({
      next: () => {
        this.toastr.success('Lote deletado com sucesso', 'Sucesso');
        this.lotes.removeAt(this.loteAtual.indice)
      },
      error: (error: any) => {
        this.toastr.error(`Erro ao tentar deletar o lote: ${this.loteAtual.id}`, 'Erro');
        console.error(error);
      }
    }).add(() => this.spinner.hide());
  }
  declineDeleteLote(): void {
    this.modalRef.hide();
  }

  public carregarEvento(): void {
    this.eventoId = +this.router.snapshot.paramMap.get('id')
    if (this.eventoId !== null && this.eventoId !== 0) {
      this.estadoSalvar = 'put';
      this.spinner.show();
      this.eventoService.getEventoById(this.eventoId).subscribe({
        next: (evento: Evento) => {
          this.evento = { ...evento };
          this.form.patchValue(this.evento);
          this.evento.lotes.forEach(lote => {
            this.lotes.push(this.criarLote(lote))
          })
        },
        error: (error: any) => {
          console.log(error)
          this.toastr.error('Erro ao tentar carregar evento', 'Erro!')
        }
      }).add(() => this.spinner.hide());
    }
  }

  // public carregarLotes(): void{
  //   this.loteService.getLotesByEventoId(this.eventoId).subscribe({
  //     next: (lotesRetorno: Lote[]) => {
  //       lotesRetorno.forEach(lote => {
  //         this.lotes.push(this.criarLote(lote))
  //       })
  //     },
  //     error: (error: any) => {
  //       this.toastr.error('Erro ao tentar carregar lotes', 'Erro')
  //     }
  //   }).add(() => this.spinner.hide());
  // }

  public resetForm(): void {
    this.form.reset();
  }

  public validation(): void {
    this.form = this.fb.group({
      tema: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      email: ['', [Validators.required, Validators.email]],
      local: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(50)]],
      dataEvento: ['', [Validators.required]],
      qtdPessoas: ['', [Validators.required, Validators.min(50), Validators.max(1000)]],
      imagemURL: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      telefone: ['', [Validators.required, Validators.minLength(9), Validators.maxLength(12)]],
      lotes: this.fb.array([])

    });
  }

  adicionarLote(): void {
    this.lotes.push(this.criarLote({ id: 0 } as Lote));
  }

  criarLote(lote: Lote): FormGroup {
    return this.fb.group({
      id: [lote.id],
      nome: [lote.nome, [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      preco: [lote.preco, Validators.required],
      dataInicio: [lote.dataFim, Validators.required],
      dataFim: [lote.dataFim, Validators.required],
      quantidade: [lote.quantidade, Validators.required],
    });
  }

  public cssValidator(campoForm: FormControl | AbstractControl): any {
    return { 'is-invalid': campoForm.errors && campoForm.touched };
  }

  public retornarTituloLote(indice: string): any {
    return indice === null || indice === ''
      ? 'Nome do lote'
      : indice;
  }

  public salvarLotes(): void {
    this.spinner.show();
    if (this.form.controls.lotes.valid) {
      this.loteService.saveLote(this.eventoId, this.form.value.lotes).subscribe({
        next: () => {
          this.toastr.success('Lote Salvo com sucesso', 'Sucesso')
          this.lotes.reset();
        },
        error: (error: any) => {
          console.error(error);
          this.toastr.error('Error ao salvar Lote', 'Erro!');
        },
      }).add(() => this.spinner.hide())

    }
  }

  public salvarEvento(): void {
    this.spinner.show();
    if (this.form.valid) {

      this.evento = (this.estadoSalvar === 'post')
        ? { ... this.form.value }
        : { id: this.evento.id, ... this.form.value };

      this.eventoService[this.estadoSalvar](this.evento).subscribe({
        next: (evento: Evento) => {
          this.toastr.success('Evento Salvo com sucesso', 'Sucesso')
          this.estadoSalvar = 'put';
        },
        error: (error: any) => {
          console.error(error);
          this.toastr.error('Error ao salvar o evento', 'Erro!');
        },
      }).add(() => this.spinner.hide());
    }
  }


}
