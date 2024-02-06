import { Injectable } from '@angular/core';
import { MatSnackBar as MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class SnackbarService {

  constructor(private _snackbar: MatSnackBar) { }

  SnackBar(message: string, action?: string)
  {
    if (action == undefined)
    this._snackbar.open(message, "Close", { duration: 3000 });

    else this._snackbar.open(message, action, { duration: 3000 });
  }
}
