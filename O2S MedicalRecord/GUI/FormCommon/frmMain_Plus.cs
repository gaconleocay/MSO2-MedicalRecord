﻿using O2S_MedicalRecord.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;

namespace O2S_MedicalRecord.GUI.FormCommon
{
    public partial class frmMain : Form
    {
        private void KiemTraPhanQuyenNguoiDung()
        {
            try
            {
                Base.SessionLogin.SessionLstPhanQuyen_ChucNang = Base.SessionLogin.SessionLstPhanQuyenNguoiDung.Where(o => o.permissiontype == 2).OrderBy(o=>o.permissioncode).ToList();
                Base.SessionLogin.SessionLstPhanQuyen_Report = Base.SessionLogin.SessionLstPhanQuyenNguoiDung.Where(o => o.permissiontype == 3).OrderBy(o => o.permissioncode).ToList();
                Base.SessionLogin.SessionLstPhanQuyen_BaoCao = Base.SessionLogin.SessionLstPhanQuyenNguoiDung.Where(o => o.permissiontype == 10).OrderBy(o => o.permissioncode).ToList();
                Base.SessionLogin.SessionLstPhanQuyen_Dashboard = Base.SessionLogin.SessionLstPhanQuyenNguoiDung.Where(o => o.permissiontype == 5).ToList();

                if (SessionLogin.SessionLstPhanQuyen_ChucNang == null || SessionLogin.SessionLstPhanQuyen_ChucNang.Count <= 0)
                {
                    tabMenuHSBA.PageVisible = false;
                }
                if (SessionLogin.SessionLstPhanQuyen_Dashboard == null || SessionLogin.SessionLstPhanQuyen_Dashboard.Count <= 0)
                {
                    tabMenuDashboard.PageVisible = false;
                }
            }
            catch (Exception ex)
            {
                O2S_MedicalRecord.Base.Logging.Warn(ex);
                throw;
            }
        }

        private void EnableAndDisableChucNang(bool enabledisable)
        {
            try
            {
                tabMenuHSBA.PageVisible = enabledisable;
                //tabMenuDashboard.PageVisible = enabledisable;
            }
            catch (Exception ex)
            {
                O2S_MedicalRecord.Base.Logging.Warn(ex);
                throw;
            }
        }

    }
}
