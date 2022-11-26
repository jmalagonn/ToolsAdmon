import { faScrewdriverWrench, faToolbox, faUserGroup, faUserPen } from "@fortawesome/free-solid-svg-icons";
import { NgxQrcodeElementTypes, NgxQrcodeErrorCorrectionLevels } from "@techiediaries/ngx-qrcode";

export class AppConstants {
    public static readonly MENU_ITEMS = [
        {
            title: 'Salida de equipos y herramienta',
            icon: faToolbox,
            path: 'tools-output'
        },
        {
            title: 'Administración de equipos y herramienta',
            icon: faScrewdriverWrench,
            path: 'tools-management'
        },
        {
            title: 'Administración de usuarios',
            icon: faUserGroup,
            path: 'users-management'
        },
        {
            title: 'Editar perfil',
            icon: faUserPen,
            path: 'profile'
        },
    ]
}

export class QRConstants {
    public static readonly QRElementType = NgxQrcodeElementTypes.IMG;
    public static readonly QRCorrectionLevel = NgxQrcodeErrorCorrectionLevels.HIGH;
}