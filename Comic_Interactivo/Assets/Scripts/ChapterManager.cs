using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// Gestiona el estado de los capítulos (bloqueado/desbloqueado).
public class ChapterManager : MonoBehaviour
{
    [System.Serializable]
    public class Chapter
    {
        public int chapterID;
        public GameObject chapterButton;

        public bool unlocked;

        // UI visual
        public Image image;
        public GameObject lockOverlay;
    }

    public List<Chapter> chapters;

    /// Verifica si un capítulo está desbloqueado.
    public bool IsChapterUnlocked(int chapterID)
    {
        Chapter chapter = chapters.Find(c => c.chapterID == chapterID);
        return chapter != null && chapter.unlocked;
    }

    /// Desbloquea un capítulo (puede llamarse desde decisiones).
    public void UnlockChapter(int chapterID)
    {
        Chapter chapter = chapters.Find(c => c.chapterID == chapterID);

        if (chapter != null)
        {
            chapter.unlocked = true;
            UpdateChapterUI();
        }
    }

    /// Actualiza la UI según estado del capítulo.
    public void UpdateChapterUI()
    {
        foreach (var chapter in chapters)
        {
            if (chapter.unlocked)
            {
                chapter.image.color = Color.white;
                chapter.lockOverlay.SetActive(false);
            }
            else
            {
                chapter.image.color = Color.gray;
                chapter.lockOverlay.SetActive(true);
            }
        }
    }
}