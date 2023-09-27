using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ProjectManagerEditorWindow : EditorWindow
{
    [MenuItem("Window/UI Toolkit/MyEditorWindow")]
    public static void ShowExample()
    {
        ProjectManagerEditorWindow wnd = GetWindow<ProjectManagerEditorWindow>();
        wnd.titleContent = new GUIContent("MyEditorWindow");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy
        Label label = new Label("Hello World!");
        root.Add(label);

        // Create button
        Button button = new Button();
        button.name = "button";
        button.text = "Button";
        root.Add(button);

        // Create toggle
        Toggle toggle = new Toggle();
        toggle.name = "toggle";
        toggle.label = "Toggle";
        root.Add(toggle);

    }
}