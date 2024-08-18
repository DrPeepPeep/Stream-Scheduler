obs = obslua

local source_names = {"Monday Time", "Tuesday Time", "Wednesday Time", "Thursday Time", "Friday Time", "Saturday Time", "Sunday Time"}

-- UI settings for the base directory
local base_directory = ""

function script_properties()
    local props = obs.obs_properties_create()
    
    -- Directory input for the base folder path
    obs.obs_properties_add_path(props, "base_directory", "Base Directory", obs.OBS_PATH_DIRECTORY, "", nil)
    
    -- Button to trigger the setup
    obs.obs_properties_add_button(props, "button", "Setup Week", button_prop_clicked)
    
    return props
end

function button_prop_clicked(props, prop)
    setup_week()
end

function setup_week()
    local directory = base_directory
    if directory == "" then
        directory = script_path() .. "StreamSchedule\\"
    else
        directory = directory .. "\\"
    end
    
    local source_width_offset = 300  -- Horizontal offset for each source
    local x_pos = 0
    local y_pos = 200  -- Vertical position for all sources

    -- Get the current scene
    local scene_source = obs.obs_frontend_get_current_scene()
    local scene = obs.obs_scene_from_source(scene_source)
    
    if scene == nil then
        print("Error: No current scene found.")
        return
    end

    for i, name in ipairs(source_names) do
        local text_file_path = directory .. name:gsub(" Time", "") .. ".txt"

        -- Create source
        local settings = obs.obs_data_create()
        obs.obs_data_set_string(settings, "file", text_file_path)
        obs.obs_data_set_bool(settings, "read_from_file", true)
        obs.obs_data_set_int(settings, "font_size", 48)

        local source = obs.obs_source_create("text_gdiplus", name, settings, nil)
        
        -- Check if the source was created successfully
        if not source then
            print("Error: Failed to create source '" .. name .. "'.")
            obs.obs_data_release(settings)
            goto continue
        end

        local scene_item = obs.obs_scene_add(scene, source)
        
        -- Check if the scene item was added successfully
        if not scene_item then
            print("Error: Failed to add source '" .. name .. "' to the scene.")
            obs.obs_source_release(source)
            obs.obs_data_release(settings)
            goto continue
        end

        -- Set the position for the source
        local pos = obs.vec2()
        pos.x = x_pos
        pos.y = y_pos
        obs.obs_sceneitem_set_pos(scene_item, pos)

        -- Move the position to the right for the next source
        x_pos = x_pos + source_width_offset

        obs.obs_source_release(source)
        obs.obs_data_release(settings)
        
        ::continue::
    end

    -- Release the scene source
    obs.obs_source_release(scene_source)
end

function script_update(settings)
    base_directory = obs.obs_data_get_string(settings, "base_directory")
end

function script_description()
    return "Creates 7 text sources named Monday Time through Sunday Time, sets them to read from files, and positions them horizontally across the scene."
end
