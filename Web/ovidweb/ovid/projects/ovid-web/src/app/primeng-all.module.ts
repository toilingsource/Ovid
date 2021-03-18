import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AutoCompleteModule } from 'primeng/autocomplete';
import { CalendarModule } from 'primeng/calendar';
import { CheckboxModule } from 'primeng/checkbox';
import { ChipsModule } from 'primeng/chips';
import { DropdownModule } from 'primeng/dropdown';
import { EditorModule } from 'primeng/editor';
import { InputMaskModule } from 'primeng/inputmask';
import { InputSwitchModule } from 'primeng/inputswitch';
import { InputTextModule } from 'primeng/inputtext';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { InputNumberModule } from 'primeng/inputnumber';
import { KeyFilterModule } from 'primeng/keyfilter';
import { ListboxModule } from 'primeng/listbox';
import { PasswordModule } from 'primeng/password';
import { RadioButtonModule } from 'primeng/radiobutton';
import { SelectButtonModule } from 'primeng/selectbutton';
import { ToggleButtonModule } from 'primeng/togglebutton';
import { ButtonModule } from 'primeng/button';
import { SplitButtonModule } from 'primeng/splitbutton';
import { DataViewModule } from 'primeng/dataview';
import { OrderListModule } from 'primeng/orderlist';
import { PaginatorModule } from 'primeng/paginator';
import { PickListModule } from 'primeng/picklist';
import { TableModule } from 'primeng/table';
import { TimelineModule } from 'primeng/timeline';
import { TreeModule } from 'primeng/tree';
import { TreeTableModule } from 'primeng/treetable';
import { VirtualScrollerModule } from 'primeng/virtualscroller';
import { AccordionModule } from 'primeng/accordion';
import { CardModule } from 'primeng/card';
import { FieldsetModule } from 'primeng/fieldset';
import { PanelModule } from 'primeng/panel';
import { ScrollPanelModule } from 'primeng/scrollpanel';
import { TabViewModule } from 'primeng/tabview';
import { ToolbarModule } from 'primeng/toolbar';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmPopupModule } from 'primeng/confirmpopup';
import { DialogModule } from 'primeng/dialog';
import { DialogService, DynamicDialogModule } from 'primeng/dynamicdialog';
import { OverlayPanelModule } from 'primeng/overlaypanel';
import { SidebarModule } from 'primeng/sidebar';
import { TooltipModule } from 'primeng/tooltip';
import { FileUploadModule } from 'primeng/fileupload';
import { MenuModule } from 'primeng/menu';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { ContextMenuModule } from 'primeng/contextmenu';
import { MegaMenuModule } from 'primeng/megamenu';
import { MenubarModule } from 'primeng/menubar';
import { PanelMenuModule } from 'primeng/panelmenu';
import { StepsModule } from 'primeng/steps';
import { TabMenuModule } from 'primeng/tabmenu';
import { TieredMenuModule } from 'primeng/tieredmenu';
import { ConfirmationService, MessageService } from 'primeng/api';
import { SlideMenuModule } from 'primeng/slidemenu';
import { ChartModule } from 'primeng/chart';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { ToastModule } from 'primeng/toast';
import { DragDropModule } from 'primeng/dragdrop';
import { CaptchaModule } from 'primeng/captcha';
import { InplaceModule } from 'primeng/inplace';
import { ProgressBarModule } from 'primeng/progressbar';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { FocusTrapModule } from 'primeng/focustrap';
import { DeferModule } from 'primeng/defer';
import { RippleModule } from 'primeng/ripple';
import { FilterService } from 'primeng/api';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MenuModule,
    AutoCompleteModule,
    CalendarModule,
    CheckboxModule,
    ChipsModule,
    DropdownModule,
    EditorModule,
    InputMaskModule,
    InputSwitchModule,
    ChipsModule,
    InputTextModule,
    InputTextareaModule,
    InputNumberModule,
    KeyFilterModule,
    ListboxModule,
    PasswordModule,
    RadioButtonModule,
    SelectButtonModule,
    ToggleButtonModule,
    ButtonModule,
    SplitButtonModule,
    DataViewModule,
    OrderListModule,
    PaginatorModule,
    PickListModule,
    TableModule,
    TimelineModule,
    TreeModule,
    TreeTableModule,
    VirtualScrollerModule,
    AccordionModule,
    CardModule,
    FieldsetModule,
    PanelModule,
    ScrollPanelModule,
    TabViewModule,
    ToolbarModule,
    ConfirmDialogModule,
    ConfirmPopupModule,
    DialogModule,
    DynamicDialogModule,
    OverlayPanelModule,
    SidebarModule,
    TooltipModule,
    FileUploadModule,
    BreadcrumbModule,
    ContextMenuModule,
    MegaMenuModule,
    StepsModule,
    MenubarModule,
    PanelMenuModule,
    SlideMenuModule,
    TabMenuModule,
    TieredMenuModule,
    ChartModule,
    MessagesModule,
    MessageModule,
    ToastModule,
    DragDropModule,
    InplaceModule,
    ProgressBarModule,
    ProgressSpinnerModule,
    FocusTrapModule,
    DeferModule,
    RippleModule

  ],
  providers: [
    ConfirmationService,
    FilterService,
    MessageService,
    DialogService
  ],
  exports:[
    MenuModule,
    AutoCompleteModule,
    CalendarModule,
    CheckboxModule,
    ChipsModule,
    DropdownModule,
    EditorModule,
    InputMaskModule,
    InputSwitchModule,
    InputTextModule,
    InputTextareaModule,
    InputNumberModule,
    KeyFilterModule,
    ListboxModule,
    ChipsModule,
    PasswordModule,
    RadioButtonModule,
    SelectButtonModule,
    ToggleButtonModule,
    ButtonModule,
    SplitButtonModule,
    DataViewModule,
    OrderListModule,
    PaginatorModule,
    PickListModule,
    TableModule,
    TimelineModule,
    TreeModule,
    TreeTableModule,
    VirtualScrollerModule,
    AccordionModule,
    CardModule,
    FieldsetModule,
    PanelModule,
    ScrollPanelModule,
    TabViewModule,
    ToolbarModule,
    ConfirmDialogModule,
    ConfirmPopupModule,
    DialogModule,
    DynamicDialogModule,
    OverlayPanelModule,
    SidebarModule,
    TooltipModule,
    FileUploadModule,
    BreadcrumbModule,
    ContextMenuModule,
    MegaMenuModule,
    StepsModule,
    MenubarModule,
    PanelMenuModule,
    SlideMenuModule,
    TabMenuModule,
    TieredMenuModule,
    ChartModule,
    MessagesModule,
    MessageModule,
    ToastModule,
    DragDropModule,
    InplaceModule,
    ProgressBarModule,
    ProgressSpinnerModule,
    FocusTrapModule,
    DeferModule,
    RippleModule
  ]
})
export class PrimengAllModule { }
