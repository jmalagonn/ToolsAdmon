using API.Entities;

namespace API.Helpers
{
    public static class AppConstants
    {
        public static List<ToolState> INITIAL_TOOL_STATES = new List<ToolState> {
            new ToolState { ToolStateId = 1, ToolStateName = "Disponible" },
            new ToolState { ToolStateId = 2, ToolStateName = "Con novedad" },
            new ToolState { ToolStateId = 3, ToolStateName = "Prestado" }
        };

        public static List<UserRole> INITIAL_USER_ROLES = new List<UserRole> {
            new UserRole{UserRoleId=1,UserRoleName="AppAdmin"},
            new UserRole{UserRoleId=2,UserRoleName="CompanyAdmin"},
            new UserRole { UserRoleId = 3, UserRoleName = "CompanyEmployee" },
        };

        public static List<OutputToolState> INITIAL_OUTPUT_TOOL_STATES = new List<OutputToolState> {
            new OutputToolState{OutputToolStateId=1,OutputToolStateName="Open"},
            new OutputToolState{OutputToolStateId=2,OutputToolStateName="Closed"},
        };
    }
}
