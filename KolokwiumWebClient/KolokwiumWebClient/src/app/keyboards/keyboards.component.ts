import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { KeyboardResponseDTO } from '../model/keyboardResponse.interface';
import { KeyboardRequestDTO } from '../model/keyboardRequest.interface';
import { KeyboardsService } from '../keyboards.service';
import { KeyboardType } from '../model/keyboardType.interface';

@Component({
  selector: 'app-keyboards',
  templateUrl: './keyboards.component.html',
  styleUrl: './keyboards.component.css'
})
export class KeyboardsComponent {

  public keyboards: KeyboardResponseDTO[] = [];
  public newKeyboard: KeyboardRequestDTO;
  public isAddFormVisible: boolean = false; 

  constructor(private keyboardService: KeyboardsService) {
    this.getData();

    // new keyboard init
    this.newKeyboard = { model: 'model', type: 0 };
  }

  public getData(): void {
    this.keyboardService.getKeyboards().subscribe({
      next: (res) => {
        this.keyboards = res;
      },
      error: (err) => console.error("Error fetching keyboards data, ", err),
    });
  }

  public deleteKeyboard(selectedKeyboard: KeyboardResponseDTO): void {
    if(selectedKeyboard.id != null) {
      this.keyboardService.deleteKeyboard(selectedKeyboard.id).subscribe({
        next: () => {
          this.getData();
        }
      });
    }
  }

  public onKeyboardSubmit(): void {
    this.keyboardService.addKeyboard(this.newKeyboard).subscribe({
      next: () => {
        this.getData();
        this.isAddFormVisible = false;
        this.newKeyboard.model = 'model';
        this.newKeyboard.type = 0;
      }
    })
  }

  public getKeyboardTypeText(type: KeyboardType): string {
    switch (type) {
      case KeyboardType.membranowa:
        return 'membranowa';
      case KeyboardType.nozycowa:
        return 'nozycowa';
      case KeyboardType.mechaniczna:
        return 'mechaniczna';
      case KeyboardType.optyczna:
        return 'optyczna';
      case KeyboardType.hybrydowa:
        return 'hybrydowa';
      default:
        return '';
    }
  }

  public onAddSectionToggle(): void {
    this.isAddFormVisible = !this.isAddFormVisible;
  }
}