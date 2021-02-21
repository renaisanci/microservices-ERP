import { Component, OnInit, ElementRef, Input, OnDestroy, Optional, Self, DoCheck } from '@angular/core';
import { FormGroup, FormBuilder, NgControl,  ControlValueAccessor } from '@angular/forms';
import { Subject } from 'rxjs';
import { FocusMonitor } from '@angular/cdk/a11y';
import {coerceBooleanProperty} from '@angular/cdk/coercion';
import { MatFormFieldControl, ErrorStateMatcher } from '@angular/material';



/** Data structure for holding telephone number. */
export class InputText {
  constructor(public inputText: string) {}
}


@Component({
  selector: 'dbcorp-text-input',
  templateUrl: './text-input.component.html',
  styleUrls: ['./text-input.component.css'],
  providers: [{provide: MatFormFieldControl, useExisting: TextInputComponent}]
})
export class TextInputComponent implements MatFormFieldControl<InputText>, ControlValueAccessor, OnDestroy, OnInit, DoCheck {



  get empty() {
    const {value: {inputText }} = this.parts;
    console.log('empty >>>> ' + inputText);
    return !inputText ;
  }

  get shouldLabelFloat() { return this.focused || !this.empty; }

  @Input()
  get placeholder(): string { return this._placeholder; }
  set placeholder(value: string) {
    this._placeholder = value;
    this.stateChanges.next();
  }

  @Input()
  get required(): boolean { return this._required; }
  set required(value: boolean) {
    this._required = coerceBooleanProperty(value);
    this.stateChanges.next();
  }

  @Input()
  get disabled(): boolean { return this._disabled; }
  set disabled(value: boolean) {
    this._disabled = coerceBooleanProperty(value);
    this._disabled ? this.parts.disable() : this.parts.enable();
    this.stateChanges.next();
  }

  @Input()
  get value(): InputText | null {
    const {value: {inputText}} = this.parts;
    console.log('GET >>>> ' + inputText);
    return null;
  }
  set value(tel: InputText | null) {
    const {inputText} = tel || new InputText('');
    this.parts.setValue({ inputText });

    console.log('SET >>>> ' + inputText);

    //this.registerOnChange(inputText);
    this.stateChanges.next();
  }







  constructor(
    fb: FormBuilder, private fm: FocusMonitor,
    private elRef: ElementRef<HTMLElement>,
    public _defaultErrorStateMatcher: ErrorStateMatcher,
    @Optional() @Self() public ngControl: NgControl
  ) {



    this.parts = fb.group({
      inputText: ''
    });

    fm.monitor(elRef, true).subscribe(origin => {
      if (this.focused && !origin) {
        this.onTouched();
      }

      this.focused = !!origin;
      this.stateChanges.next();
    });




    if (this.ngControl != null) {
      this.ngControl.valueAccessor = this;
    }
  }


  static nextId = 0;
  parts: FormGroup;
  stateChanges = new Subject<void>();
  focused = false;
  errorState = false;
  controlType = 'text-input';
  id = `text-input-${TextInputComponent.nextId++}`;
  describedBy = '';
  private _placeholder: string;
  private _required = false;
  private _disabled = false;
  onChange = (_: any) => {};
  onTouched = () => {};

  ngOnInit() {
  }



  ngOnDestroy() {
    this.stateChanges.complete();
    this.fm.stopMonitoring(this.elRef);
  }

  setDescribedByIds(ids: string[]) {
    this.describedBy = ids.join(' ');
  }

  onContainerClick(event: MouseEvent) {

    console.log(' onContainerClick   ' );

    if ((event.target as Element).tagName.toLowerCase() != 'input') {
      this.elRef.nativeElement.querySelector('input')!.focus();
    }
  }


  writeValue(tel: InputText | null): void {
    this.value = tel;


    console.log(' writeValue   ' );
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;

    console.log(' onChange   ' );
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;


    console.log(' registerOnTouched   ' );
  }

  setDisabledState(isDisabled: boolean): void {
    this.disabled = isDisabled;


  }

  _handleInput(): void {
    this.onChange(this.parts.value);
  }


  ngDoCheck(): void {
    if (this.ngControl) {
      this.errorState = !this.ngControl.invalid && this.ngControl.touched;


      if (this.ngControl.errors) {
        this.errorState = false;
}

      this.stateChanges.next();

    //  console.log(' invalid   ' + this.ngControl.invalid);
    //  console.log(' touched   ' + this.ngControl.touched);

     // console.log('Erros >> ' + this.ngControl.errors );
    }





 }
}
