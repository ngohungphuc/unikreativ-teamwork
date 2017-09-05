import { OpaqueToken, Injectable } from '@angular/core'

export let Toastr_Token = new OpaqueToken('toastr')

export interface Toastr {
  success (msg: string, title?: string): void
  info (msg: string, title?: string): void
  warning (msg: string, title?: string): void
  error (msg: string, title?: string): void
}